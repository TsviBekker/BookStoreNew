using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Services.Cart.Checkout
{
    public interface ICheckoutService
    {
        bool ValidateCard(string cardNumber, int month, int year, int CC);

        //bool ValidateFirstDigit(int digit);
        //bool ValidateLength(string cardNumber);
        //bool ValidateExpirationDate(DateTime expirationDate);
    }
}
