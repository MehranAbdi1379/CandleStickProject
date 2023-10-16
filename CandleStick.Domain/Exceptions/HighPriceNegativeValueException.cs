using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Domain.Exceptions
{
    public class HighPriceNegativeValueException: Exception
    {
        public override string Message => ExceptionMessages.HighPriceNegativeValueExceptionMessage;
    }
}
