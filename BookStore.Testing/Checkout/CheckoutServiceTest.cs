using BookStore.Service.Exceptions.CardExceptions;
using BookStore.Service.Services.Cart.Checkout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStore.Testing.Checkout
{
    [TestClass]
    public class CheckoutServiceTest
    {
        private readonly ICheckoutService checkoutService;
        public string CrediCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int CardCC { get; set; }
        public CheckoutServiceTest()
        {
            //Normal input
            CrediCardNumber = "4876111100232427";
            ExpirationYear = 25;
            ExpirationMonth = 5;
            CardCC = 555;

            checkoutService = new CheckoutService();
        }

        [TestMethod]
        public void Validate_Card_Test_Normal_Input()
        {
            var isValid = checkoutService.ValidateCard(CrediCardNumber, ExpirationMonth, ExpirationYear, CardCC);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void Validate_Card_Test_Invalid_First_Char()
        {
            string creditCardNumber = CrediCardNumber;
            creditCardNumber = creditCardNumber.Replace(creditCardNumber[0], '1');
            Assert.ThrowsException<InvalidFirstDigitException>(() => checkoutService.ValidateCard(creditCardNumber, ExpirationMonth, ExpirationYear, CardCC));
            creditCardNumber = creditCardNumber.Replace(creditCardNumber[0], '2');
            Assert.ThrowsException<InvalidFirstDigitException>(() => checkoutService.ValidateCard(creditCardNumber, ExpirationMonth, ExpirationYear, CardCC));
            creditCardNumber = creditCardNumber.Replace(creditCardNumber[0], '8');
            Assert.ThrowsException<InvalidFirstDigitException>(() => checkoutService.ValidateCard(creditCardNumber, ExpirationMonth, ExpirationYear, CardCC));
        }

        [TestMethod]
        public void Validate_Card_Test_Invalid_Card_Input()
        {
            string creditCardNumber = CrediCardNumber.Remove(12); //too short

            Assert.ThrowsException<ArgumentException>(() => checkoutService.ValidateCard(creditCardNumber, ExpirationMonth, ExpirationYear, CardCC));

            creditCardNumber = CrediCardNumber + "1"; //too long

            Assert.ThrowsException<ArgumentException>(() => checkoutService.ValidateCard(creditCardNumber, ExpirationMonth, ExpirationYear, CardCC));

            //CC
            Assert.ThrowsException<ArgumentNullException>(() => checkoutService.ValidateCard(CrediCardNumber, ExpirationMonth, ExpirationYear, 95));
        }

        [TestMethod]
        public void Validate_Card_Test_Invalid_MonthYear_Input()
        {
            //today
            int expirationYear = DateTime.Now.Year - 2000;
            int expirationMonth = DateTime.Now.Month;

            Assert.ThrowsException<ExpiredCardException>(() => checkoutService.ValidateCard(CrediCardNumber, expirationMonth, expirationYear, CardCC));
            //invalid month
            Assert.ThrowsException<ArgumentNullException>(() => checkoutService.ValidateCard(CrediCardNumber, 13, ExpirationYear, CardCC));
            //invalid year
            Assert.ThrowsException<ArgumentNullException>(() => checkoutService.ValidateCard(CrediCardNumber, expirationMonth, 0, CardCC));

        }
    }
}
