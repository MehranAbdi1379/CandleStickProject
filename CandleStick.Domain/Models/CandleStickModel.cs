using CandleStick.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Domain.Models
{
    public class CandleStickModel
    {
        public Guid Id { get; private set; }
        public decimal OpenPrice { get; private set; }
        public decimal ClosePrice { get; private set; }
        public decimal HighPrice { get; private set; }
        public decimal LowPrice { get; private set; }
        public decimal? AveragePrice { get; private set; }


        public CandleStickModel(decimal openPrice, decimal closePrice, decimal highPrice, decimal lowPrice)
        {
            SetId();
            SetOpenPrice(openPrice);
            SetClosePrice(closePrice);
            SetHighPrice(highPrice);
            SetLowPrice(lowPrice);
        }

        public CandleStickModel()
        {
            
        }


        private void SetId()
        {
            Id = Guid.NewGuid();
        }

        public void SetOpenPrice(decimal openPrice)
        {
            if (openPrice < 0)
                throw new OpenPriceNegativeValueException();
            OpenPrice = openPrice;
        }

        public void SetClosePrice(decimal closePrice)
        {
            if(closePrice < 0)
                throw new ClosePriceNegativeValueException();
            ClosePrice = closePrice;
        }

        public void SetHighPrice(decimal highPrice)
        {
            if(highPrice < 0)
                throw new HighPriceNegativeValueException();
            HighPrice = highPrice;
        }

        public void SetLowPrice(decimal lowPrice)
        {
            if(lowPrice < 0)
                throw new LowPriceNegativeValueException();
            LowPrice = lowPrice;
        }

        public void SetAveragePrice(bool nullTheAverage = false)
        {
            if (nullTheAverage)
                AveragePrice = null;
            else
                AveragePrice = (OpenPrice + ClosePrice + HighPrice + LowPrice) / 4;
        }
    }
}
