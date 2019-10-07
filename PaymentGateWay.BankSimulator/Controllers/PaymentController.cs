using CreditCardValidator;
using Entities.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PaymentGateWay.BankSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("", Name = "Payment")]
       
        public ActionResult<PaymentDetails> Post([FromBody] Card card)
        {
            var cardnumber = new CreditCardDetector(card.cardnumber.ToString());

            var payment = new PaymentDetails
            {
                cvv=card.cvv,
                currency=card.currency,
                ExpiryMonth=card.ExpiryMonth,
                cardnumber=card.cardnumber,
                PaymentID = Guid.NewGuid()
            };

            if (cardnumber.IsValid())
            {
                payment.statuscode = "Payment Successful";

            }
            else
            {
                payment.statuscode = "Payment unsuccessful";
            }

            return Ok(payment);
        }
    }
}