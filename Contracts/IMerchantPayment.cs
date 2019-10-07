using Entities.Model;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMerchantPayment : IRepositoryBase<MerchantTransaction>
    {
       Task<MerchantTransaction> CreateMerchantRequestAsync(Card card);
    }
}
