using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Exceptions.CardExceptions
{
    public class InvalidFirstDigitException : Exception
    {
        public int Digit { get; set; }

        public InvalidFirstDigitException(int digit)
        {
            Digit = digit;
        }
        public InvalidFirstDigitException(int digit, string message) : base(message)
        {
            Digit = digit;
        }
        public InvalidFirstDigitException(int digit, string message, Exception innerException) : base(message, innerException)
        {
            Digit = digit;
        }
    }
}
