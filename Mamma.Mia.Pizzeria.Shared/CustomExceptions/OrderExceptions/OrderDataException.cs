using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Shared.CustomExceptions.OrderExceptions
{
    public class OrderDataException : Exception
    {
        public OrderDataException(string message) : base(message) { }
    }
}
