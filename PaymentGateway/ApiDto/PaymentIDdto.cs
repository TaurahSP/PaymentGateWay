using Contracts;
using System;

namespace PaymentGateway.ApiDto
{
    public class PaymentIDdto : IEntity
    {
        public Guid Id { get; set; }
    }
}
