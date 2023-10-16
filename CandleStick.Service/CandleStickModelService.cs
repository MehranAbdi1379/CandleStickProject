using CandleStick.Domain.Models;
using CandleStick.Infranstructure;
using CandleStick.Service.CQRS.CandleStick.Commands;
using CandleStick.Service.CQRS.CandleStick.Queries;
using CandleStick.Service.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service
{
    public class CandleStickModelService
    {
        private readonly IMediator mediator;

        public CandleStickModelService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Add(CandleStickModelDTO dto) => mediator.Send(new CandleStickModelCreateCommand(dto));
        public void Update(Guid id,CandleStickModelDTO dto) => mediator.Send(new CandleStickModelUpdateCommand(id,dto));
        public void Delete(Guid id) => mediator.Send(new CandleStickModelDeleteCommand(id));
        public Task<List<CandleStickModel>> GetAll() => mediator.Send(new CandleStickModelGetAllQuery());
        public Task<CandleStickModel> Get(Guid id) => mediator.Send(new CandleStickModelGetByIdQuery(id));
    }
}
