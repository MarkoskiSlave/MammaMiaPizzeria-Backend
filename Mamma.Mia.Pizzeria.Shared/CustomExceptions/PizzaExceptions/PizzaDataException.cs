using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Shared.CustomExceptions.PizzaExceptions
{
    public class PizzaDataException : Exception
    {
        public PizzaDataException(string message) : base(message) { }
    }
}
