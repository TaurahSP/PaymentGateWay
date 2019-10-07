
using AutoMapper;
using Contracts;
using Entities.Model;
using LazyCache;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.ApiDto;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.Controllers
{
    [Route("api/paymentdetail")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        #region dependencies
        private ILogger _logger;

        private IRepositoryWrapper _repoWrapper;

        private IMapper _mapper;
        #endregion

        private IAppCache AppCache { get; }
        public PaymentDetailController(IAppCache appCache, ILogger logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            AppCache = appCache;
            _logger = logger;
            _repoWrapper = repoWrapper;
            _mapper = mapper;

        }

        /// <summary>
        /// Returns payment details for a specific id
        /// </summary>
        /// <param name="id">Unique Identifier of Payment being requested</param>
        /// <returns>
        /// Payment Details and status
        /// </returns>
        /// <response code="404">Requested Payment ID not found</response>
        /// <response code="200">Returns payment details for Id queried</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(Guid id)
        {

            var paymentdetails = await _repoWrapper.bankPayment.GetPaymentDetailsByIdAsync(id);

            var paymentdetailsdto = _mapper.Map<PaymentDetailsdto>(paymentdetails);

            if (paymentdetails.PaymentID.Equals(Guid.Empty))
            {
                _logger.Information($"Payment with id: {id}, hasn't been found in db.");

                return NotFound();
            }
            else
            {

                _logger.Information($"Returned Payment with id: {id}");

                return Ok(AppCache.GetOrAdd("PaymentByID", () => paymentdetailsdto));


            }



        }

        /// <summary>
        /// Process card details from merchant
        /// </summary>
        /// <param name="cardto">card details</param>
        /// <response code="200">Card process successfully</response>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentDetailsdto),200)]
        public async Task<IActionResult> CreateMerchantRequest(Carddto cardto)
        {
            //mapping carddto to domain model card

            var card = _mapper.Map<Card>(cardto);

            //create a new Merchanttransaction object

            var merchanttransaction = await _repoWrapper.merchantPayment.CreateMerchantRequestAsync(card);

            //send card details to Bank for processing

            var bankresponse = await _repoWrapper.bankPayment.SendBank(card);

            //update merchanttransaction 
            merchanttransaction.ResponseReceived = DateTime.Now;

            _repoWrapper.merchantPayment.Update(merchanttransaction);

            await _repoWrapper.merchantPayment.SaveAsync();
            
            //save bank response in db
            await _repoWrapper.bankPayment.CreateBankPaymentAsync(bankresponse);

            //mapping domain model-PaymentDetails to paymentDetailsdto
            var paymentDetailsdto = _mapper.Map<PaymentDetails>(bankresponse);


            return Ok(paymentDetailsdto.statuscode);


        }

       

        

    }
}