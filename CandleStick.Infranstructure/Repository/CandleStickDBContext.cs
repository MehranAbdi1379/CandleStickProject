using CandleStick.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Infranstructure.Repository
{
    public class CandleStickDBContext: DbContext
    {
        public CandleStickDBContext(DbContextOptions<CandleStickDBContext> options) : base(options) { }

        public DbSet<CandleStickModel> CandleSticks{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CandleStickModelConfiguration());
        }
    }
}
