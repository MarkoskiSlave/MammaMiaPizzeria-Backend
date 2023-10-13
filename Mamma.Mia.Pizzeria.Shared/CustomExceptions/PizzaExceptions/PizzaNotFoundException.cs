using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamma.Mia.Pizzeria.Shared.CustomExceptions.PizzaExceptions
{
    public class PizzaNotFoundException : Exception
    {
        public PizzaNotFoundException(string message) : base(message) { }
    }
}
