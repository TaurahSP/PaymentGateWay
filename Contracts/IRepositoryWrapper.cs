namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IBankPayment bankPayment { get; }

        IMerchantPayment merchantPayment { get; set; }

        
    }
}
