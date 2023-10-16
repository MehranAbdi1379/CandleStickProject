using CandleStick.Domain.Exceptions;
using CandleStick.Domain.Models;

namespace CandleStick.Domain.Test
{

    [TestClass]
    public class CandleStickModelTests
    {
        [TestMethod]
        public void CandleStickModel_Creation_WithValidPrices()
        {
            decimal openPrice = 10.0M;
            decimal closePrice = 12.0M;
            decimal highPrice = 15.0M;
            decimal lowPrice = 8.0M;

            var candlestick = new CandleStickModel(openPrice, closePrice, highPrice, lowPrice);

            Assert.IsNotNull(candlestick.Id);
            Assert.AreEqual(openPrice, candlestick.OpenPrice);
            Assert.AreEqual(closePrice, candlestick.ClosePrice);
            Assert.AreEqual(highPrice, candlestick.HighPrice);
            Assert.AreEqual(lowPrice, candlestick.LowPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenPriceNegativeValueException))]
        public void CandleStickModel_SetOpenPrice_NegativeValue_ThrowsException()
        {
            var candlestick = new CandleStickModel();

            candlestick.SetOpenPrice(-5.0M);
        }

        [TestMethod]
        [ExpectedException(typeof(ClosePriceNegativeValueException))]
        public void CandleStickModel_SetClosePrice_NegativeValue_ThrowsException()
        {
            var candlestick = new CandleStickModel();

            candlestick.SetClosePrice(-5.0M);
        }

        [TestMethod]
        [ExpectedException(typeof(HighPriceNegativeValueException))]
        public void CandleStickModel_SetHighPrice_NegativeValue_ThrowsException()
        {
            var candlestick = new CandleStickModel();

            candlestick.SetHighPrice(-5.0M);
        }

        [TestMethod]
        [ExpectedException(typeof(LowPriceNegativeValueException))]
        public void CandleStickModel_SetLowPrice_NegativeValue_ThrowsException()
        {
            var candlestick = new CandleStickModel();

            candlestick.SetLowPrice(-5.0M);
        }

        [TestMethod]
        public void CandleStickModel_SetAveragePrice_NullAverage()
        {
            var candlestick = new CandleStickModel(10.0M, 12.0M, 15.0M, 8.0M);

            candlestick.SetAveragePrice(true);

            Assert.IsNull(candlestick.AveragePrice);
        }

        [TestMethod]
        public void CandleStickModel_SetAveragePrice_CalculateAverage()
        {
            var candlestick = new CandleStickModel(10.0M, 12.0M, 15.0M, 8.0M);

            candlestick.SetAveragePrice();

            Assert.AreEqual(11.25M, candlestick.AveragePrice);
        }
    }

}