using BookStore.Service.Exceptions.CardExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services.Cart.Checkout
{
    public class CheckoutService : ICheckoutService
    {
        public DateTime ExpDate { get; set; }
        private readonly int[] VALID_FIRST_DIGITS = { 3, 4, 5, 6 };
        //Ctor
        public CheckoutService()
        {

        }

        public bool ValidateCard(string cardNumber, int month, int year, int CC)
        {
            try
            {
                if (cardNumber == null || month <= 0 || month >= 13 || year <= 00 || CC < 100 || CC > 999)
                    throw new ArgumentNullException("Some inputs are invalid.");

                ValidateFirstDigit(int.Parse(cardNumber[0].ToString()));

                ValidateExpirationDate(new DateTime(year + 2000, month, 1));

                ValidateCardNumberLength(cardNumber);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateCardNumberLength(string cardNumber)
        {
            if (cardNumber.Length > 16 || cardNumber.Length < 13)
                throw new ArgumentException("Provided card number is invalid.", cardNumber);
        }

        private void ValidateFirstDigit(int digit)
        {
            if (!VALID_FIRST_DIGITS.Contains(digit))
                throw new InvalidFirstDigitException(digit, $"Card number can't start with '{digit}'.");
        }

        private void ValidateExpirationDate(DateTime date)
        {
            if (DateTime.Now >= date)
                throw new ExpiredCardException(date, "Card has expired.");
        }
    }
}
