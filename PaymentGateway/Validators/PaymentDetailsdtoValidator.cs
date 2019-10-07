using FluentValidation;
using PaymentGateway.ApiDto;

namespace PaymentGateway.Validators
{
    public class PaymentDetailsdtoValidator : AbstractValidator<PaymentDetailsdto>
    {
        public PaymentDetailsdtoValidator()
        {
            RuleFor(x => x.cvv)
           .NotEmpty()
           .GreaterThan(1000)
           .LessThan(9999)
           .WithMessage("cvv must be 4 integer");

            RuleFor(x => x.currency)
                .NotEmpty()
                .WithMessage("Currency cannot be empty");

            RuleFor(x => x.ExpiryMonth)
                .NotEmpty()
                .WithMessage("Expiry Month cannot be empty");

            RuleFor(x => x.cardnumber)
               .NotEmpty()
               .Length(16)
               .WithMessage("cardnumber should be 16 characters");



        }
    }
}
