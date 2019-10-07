using Contracts;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentDetailRepository : RepositoryBase<PaymentDetails>, IBankPayment
    {
        public static HttpClient httpClient = new HttpClient();
        public PaymentDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateBankPaymentAsync(PaymentDetails paymentDetails)
        {

            Create(paymentDetails);

            await SaveAsync();
        }

        public async Task<PaymentDetails> GetPaymentDetailsByIdAsync(Guid paymentId)
        {
            return await FindByCondition(payment => payment.PaymentID.Equals(paymentId))
            .DefaultIfEmpty(new PaymentDetails())
            .SingleOrDefaultAsync();
        }

        /// <summary>
        /// send payment details to bank for processing
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<PaymentDetails> SendBank(Card card)
        {
            var bankResponse = await ProcessPayment(card);

            return bankResponse;
        }

        private async Task<PaymentDetails> ProcessPayment(Card card)
        {

            using (var handler = new System.Net.Http.HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

                using (var httpClient = new System.Net.Http.HttpClient(handler))
                {


                    string apiPath = "/api/payment";

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string uri = "https://localhost:44394" + apiPath;

                    var response = await httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(card), Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {

                        var content = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<PaymentDetails>(content);
                    }
                }

            }





            return null;
        }


    }
}

