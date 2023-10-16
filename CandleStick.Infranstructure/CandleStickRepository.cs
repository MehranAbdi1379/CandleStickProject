using CandleStick.Domain.Models;
using CandleStick.Infranstructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Infranstructure
{
    public class CandleStickRepository
    {
        private readonly CandleStickDBContext context;
        public CandleStickRepository(CandleStickDBContext context)
        {
            this.context = context;
        }

        public void Add(CandleStickModel candleStick)
        {
            context.Set<CandleStickModel>().Add(candleStick);
        }

        public void Delete(CandleStickModel candleStick)
        {
            context.Set<CandleStickModel>().Remove(candleStick);
        }

        public void Update(CandleStickModel candleStick)
        {
            context.Set<CandleStickModel>().Update(candleStick);
        }

        public List<CandleStickModel> GetAll()
        {
            return context.Set<CandleStickModel>().ToList();
        }

        public CandleStickModel Get(Guid id)
        {
            return context.Set<CandleStickModel>().Where(c => c.Id == id).First();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
