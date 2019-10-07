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
            
        }

        public DbSet<MerchantTransaction> merchantTransactions { get; set;}

        public DbSet<PaymentDetails> PaymentDetails { get; set; }

       
    }
}
