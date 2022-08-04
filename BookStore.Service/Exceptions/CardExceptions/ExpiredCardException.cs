using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Exceptions.CardExceptions
{
    public class ExpiredCardException : Exception
    {
        public DateTime Date { get; set; }

        public ExpiredCardException(DateTime date)
        {
            Date = date;
        }
        public ExpiredCardException(DateTime date, string message) : base(message)
        {
            Date = date;
        }
        public ExpiredCardException(DateTime date, string message, Exception innerException) : base(message, innerException)
        {
            Date = date;
        }

    }
}

