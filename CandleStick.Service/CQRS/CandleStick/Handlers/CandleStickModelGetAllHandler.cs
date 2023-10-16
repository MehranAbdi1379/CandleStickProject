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
    public class CandleStickModelGetAllHandler : IRequestHandler<CandleStickModelGetAllQuery, List<CandleStickModel>>
    {
        private readonly CandleStickRepository repository;
        public CandleStickModelGetAllHandler(CandleStickRepository repository)
        {
            this.repository = repository;
        }
        Task<List<CandleStickModel>> IRequestHandler<CandleStickModelGetAllQuery, List<CandleStickModel>>.Handle(CandleStickModelGetAllQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.GetAll());
        }
    }
}
