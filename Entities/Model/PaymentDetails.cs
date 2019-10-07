using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    [Table("PaymenDetails")]
    public class PaymentDetails
    {
        [Key]
        public Guid PaymentID { get; set; }

        
        public int cvv { get; set; }

       
        public long cardnumber { get; set; }

      
        public string currency { get; set; }

        
        public DateTime ExpiryMonth { get; set; }

        public string statuscode { get; set; }
    }
}
