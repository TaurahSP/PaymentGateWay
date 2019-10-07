using PaymentGateway.ApiDto;
using Swashbuckle.AspNetCore.Filters;

namespace PaymentGateway.SwaggerExample.Responses
{
    public class bankreponsedtoExample : IExamplesProvider<PaymentDetailsdto>
    {
        public PaymentDetailsdto GetExamples()
        {
            return new PaymentDetailsdto
            {
                statuscode="Status of Payment Processed"

            };
        }
    }
}
