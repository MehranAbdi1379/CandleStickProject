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
    public class CandleStickModelDeleteHandler : IRequestHandler<CandleStickModelDeleteCommand, CandleStickModel>
    {
        private readonly CandleStickRepository repository;
        public CandleStickModelDeleteHandler(CandleStickRepository repository)
        {
            this.repository = repository;
        }
        public Task<CandleStickModel> Handle(CandleStickModelDeleteCommand request, CancellationToken cancellationToken)
        {
            var candleStick = repository.Get(request.id);
            repository.Delete(candleStick);
            repository.SaveChanges();
            return Task.FromResult(candleStick);
        }
    }
}
