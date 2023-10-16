using CandleStick.Domain.Models;
using CandleStick.Infranstructure;
using CandleStick.Service.CQRS.CandleStick.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service.CQRS.CandleStick.Handlers
{
    public class CandleStickModelUpdateHandler : IRequestHandler<CandleStickModelUpdateCommand, CandleStickModel>
    {
        private readonly CandleStickRepository repository;
        public CandleStickModelUpdateHandler(CandleStickRepository repository)
        {
            this.repository = repository;
        }
        public Task<CandleStickModel> Handle(CandleStickModelUpdateCommand request, CancellationToken cancellationToken)
        {
            var candleStick = repository.Get(request.id);
            candleStick.SetClosePrice(request.dto.ClosePrice);
            candleStick.SetOpenPrice(request.dto.OpenPrice);
            candleStick.SetLowPrice(request.dto.LowPrice);
            candleStick.SetHighPrice(request.dto.HighPrice);
            candleStick.SetAveragePrice(true);

            repository.Update(candleStick);
            repository.SaveChanges();

            return Task.FromResult(candleStick);
        }
    }
}
