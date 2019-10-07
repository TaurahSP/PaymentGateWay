using Contracts;
using System;

namespace PaymentGateway.ApiDto
{
    public class PaymentDetailsdto :IEntity
    {

        public int cvv { get; set; }

        public string cardnumber { get; set; }


        public string currency { get; set; }


        public DateTime ExpiryMonth { get; set; }

        public string statuscode { get; set; }
        public Guid Id { get; set;}
    }
}
