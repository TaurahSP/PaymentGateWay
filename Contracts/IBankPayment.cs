using Entities.Model;
using System;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBankPayment : IRepositoryBase<PaymentDetails>
    {
        Task<PaymentDetails> GetPaymentDetailsByIdAsync(Guid paymentId);

        Task CreateBankPaymentAsync(PaymentDetails paymentDetails);

        Task<PaymentDetails> SendBank(Card card);


    }
}

