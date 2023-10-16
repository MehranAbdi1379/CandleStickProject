using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Domain.Exceptions
{
    public class OpenPriceNegativeValueException : Exception
    {
        public override string Message => ExceptionMessages.OpenPriceNegativeValueExceptionMessage;
    }
}
