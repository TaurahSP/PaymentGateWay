using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Card 
    {

       
        public int cvv { get; set; }

       
        public long cardnumber { get; set; }

       
        public string currency { get; set; }

       
        public DateTime ExpiryMonth { get; set; }
        
    }
}
