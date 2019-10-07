using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;

        private IMerchantPayment _merchantPayment;

        private IBankPayment _bankPayment;


        public IBankPayment bankPayment {


            get
            {
                if (_bankPayment == null)
                {
                    _bankPayment = new PaymentDetailRepository(_repoContext);
                }

                return _bankPayment;
            }

            set
            {
                if (_bankPayment != null)
                {
                    _bankPayment = new PaymentDetailRepository(_repoContext);
                }


            }
        }

        public IMerchantPayment merchantPayment {

            get
            {
                if (_merchantPayment == null)
                {
                    _merchantPayment = new MerchantPaymentRepository(_repoContext);
                }

                return _merchantPayment;
            }

            set
            {
                if (_merchantPayment != null)
                {
                    _merchantPayment = new MerchantPaymentRepository(_repoContext);
                }

               
            }

        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAsync()
        {
            await this._repoContext.SaveChangesAsync();
        }
    }
}
 