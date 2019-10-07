using FluentValidation.TestHelper;
using PaymentGateway.Validators;
using System;
using Xunit;

namespace PaymentGateway.Test.UnitTest
{
    public class PaymentDetailsdtoValidatorTests
    {
        [Fact]
        public void WhenCardNumberLessthan16Characters_ShouldHaveError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldHaveValidationErrorFor(m => m.cardnumber, "123455");
        }
        [Fact]
        public void WhenCardNumberIs16Characters_ShouldHaveNoError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldNotHaveValidationErrorFor(m => m.cardnumber, "1234567891234567");
        }

        [Fact]
        public void WhenCvvLessthan4Characters_ShouldHaveError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldHaveValidationErrorFor(m => m.cvv, 123);
        }
        [Fact]
        public void WhenHaveCvv_ShouldHaveNoError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldNotHaveValidationErrorFor(m => m.cvv, 1234);
        }
        [Fact]
        public void WhenCvvGreaterthanFourDigits_ShouldHaveError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldHaveValidationErrorFor(m => m.cvv, 12345);
        }
        [Fact]
        public void WhenHaveCurrencyNull_ShouldHaveError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldHaveValidationErrorFor(m => m.currency, null as string);
        }

        [Fact]
        public void WhenHaveCurrency_ShouldHaveNoError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldNotHaveValidationErrorFor(m => m.currency, "MUR");
        }


        [Fact]
        public void WhenHaveExpiryMonth_ShouldHaveNoError()
        {
            var sut = new PaymentDetailsdtoValidator();
            sut.ShouldNotHaveValidationErrorFor(m => m.ExpiryMonth, DateTime.Now);
        }
    }
}
