using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
       
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
            AddTestData();
        }

        public DbSet<MerchantTransaction> merchantTransactions { get; set;}

        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        public void AddTestData()
        {
            var payment = new PaymentDetails()
            {
                cardnumber = 1234567891234567,
                PaymentID = new Guid("4f218664-22a3-4ea6-f1eb-08d748f94977"),
                cvv=1234,
                ExpiryMonth=DateTime.Now,
                currency="MUR",
                statuscode="PAYMENT SUCCESS"
            };

            PaymentDetails.Add(payment);

            SaveChangesAsync();
        }
    }
}
