using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model
{
    [Table("MerchantTransaction")]
    public class MerchantTransaction
    {
        [Key]
        public int Id { get; set; }

        
        public int cvv { get; set; }

       
        public long cardnumber { get; set; }

        
        public string currency { get; set; }

       
        public DateTime ExpiryMonth { get; set; }

        public DateTime RequestReceived { get; set; }

        public DateTime ResponseReceived { get; set; }


    }
}
