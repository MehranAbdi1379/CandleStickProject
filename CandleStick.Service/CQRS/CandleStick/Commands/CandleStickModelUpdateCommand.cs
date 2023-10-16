using CandleStick.Domain.Models;
using CandleStick.Service.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Service.CQRS.CandleStick.Commands
{
    public record CandleStickModelUpdateCommand(Guid id,CandleStickModelUpdateDTO dto): IRequest<CandleStickModel>;
}
