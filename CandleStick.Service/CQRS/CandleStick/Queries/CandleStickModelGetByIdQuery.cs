using CandleStick.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service.CQRS.CandleStick.Queries
{
    public record CandleStickModelGetByIdQuery(Guid id): IRequest<CandleStickModel>;
}
