using Contracts;
using Entities;
using Entities.Model;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class MerchantPaymentRepository : RepositoryBase<MerchantTransaction>, IMerchantPayment
    {

        public MerchantPaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
           
        }

       
        public async Task<MerchantTransaction> CreateMerchantRequestAsync(Card card)
        {
           

            var merchanttransaction = new MerchantTransaction()
            {             
                ExpiryMonth = card.ExpiryMonth,
                cardnumber = card.cardnumber,
                currency = card.currency,
                cvv = card.cvv,
                RequestReceived = DateTime.Now
            };

            

            Create(merchanttransaction);

            await SaveAsync();

            return merchanttransaction;
        }


    }
}
