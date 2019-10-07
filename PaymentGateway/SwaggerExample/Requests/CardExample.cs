using Entities.Model;
using PaymentGateway.ApiDto;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Globalization;

namespace PaymentGateway.SwaggerExample
{
    public class CardExample : IExamplesProvider<Carddto>
    {
        CultureInfo ci = CultureInfo.InvariantCulture;


        public Carddto GetExamples()
        {
            return new Carddto
            {

                cvv = 1234,
                cardnumber = 1234567891234567,
                currency = "MUR",
                ExpiryMonth = DateTime.ParseExact("12/25/2008", "MM/dd/yyyy", ci)
            };

        }
    }
}
