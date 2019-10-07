using System;

namespace PaymentGateway.ApiDto
{
    public class Carddto
    {
        
        public int cvv { get; set; }

       
        public long cardnumber { get; set; }

        
        public string currency { get; set; }

       
        public DateTime ExpiryMonth { get; set; }
        
    }
}
