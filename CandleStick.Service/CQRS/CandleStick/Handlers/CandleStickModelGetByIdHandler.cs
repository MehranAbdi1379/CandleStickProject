using CandleStick.Domain.Models;
using CandleStick.Infranstructure;
using CandleStick.Service.CQRS.CandleStick.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service.CQRS.CandleStick.Handlers
{
    public class CandleStickModelGetByIdHandler : IRequestHandler<CandleStickModelGetByIdQuery, CandleStickModel>
    {
        private readonly CandleStickRepository repository;
        public CandleStickModelGetByIdHandler(CandleStickRepository repository)
        {
            this.repository = repository;
        }
        public Task<CandleStickModel> Handle(CandleStickModelGetByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.Get(request.id));
        }
    }
}
