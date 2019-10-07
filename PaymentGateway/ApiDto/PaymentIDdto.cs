using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.ApiDto
{
    public class PaymentIDdto : IEntity
    {
        public Guid Id { get; set; }
    }
}
