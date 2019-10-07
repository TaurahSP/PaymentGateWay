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

        [Required(ErrorMessage = "Cvv is required")]
        [Range(1000, 9999, ErrorMessage = "Cvv should be 4 number")]
        public int cvv { get; set; }

        [Required(ErrorMessage = "cardnumber is required")]
        [Range(1000000000000000, 9999999999999999, ErrorMessage = "cardnumber should be 16 number")]
        public long cardnumber { get; set; }

        [Required(ErrorMessage = "currency is required")]
        public string currency { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime ExpiryMonth { get; set; }

        public string statuscode { get; set; }
    }
}
