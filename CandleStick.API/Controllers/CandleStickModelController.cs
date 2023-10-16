using CandleStick.Domain.Models;
using CandleStick.Service;
using CandleStick.Service.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CandleStick.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandleStickModelController : ControllerBase
    {
        private readonly CandleStickModelService service;
        public CandleStickModelController(CandleStickModelService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<List<CandleStickModel>> Get() => await service.GetAll();

        [HttpGet("{id}")]
        public async Task<CandleStickModel> Get(Guid id) => await service.Get(id);

        [HttpPost]
        public async void Post([FromBody] CandleStickModelDTO dto) => service.Add(dto);

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CandleStickModelDTO dto) => service.Update(id, dto);

        [HttpDelete("{id}")]
        public void Delete(Guid id) => service.Delete(id);
    }
}
