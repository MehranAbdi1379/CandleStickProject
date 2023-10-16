using CandleStick.Domain.Models;
using CandleStick.Infranstructure;
using CandleStick.Service.CQRS.CandleStick.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service.CQRS.CandleStick.Handlers
{
    public class CandleStickModelCreateHandler : IRequestHandler<CandleStickModelCreateCommand, CandleStickModel>
    {
        private readonly CandleStickRepository repository;
        public CandleStickModelCreateHandler(CandleStickRepository repository)
        {
            this.repository = repository;
        }
        public Task<CandleStickModel> Handle(CandleStickModelCreateCommand request, CancellationToken cancellationToken)
        {
            var newCandleStick = new CandleStickModel(request.dto.OpenPrice, request.dto.ClosePrice,
                request.dto.HighPrice, request.dto.LowPrice);
            repository.Add(newCandleStick);
            repository.SaveChanges();
            return Task.FromResult(newCandleStick);
        }
    }
}
