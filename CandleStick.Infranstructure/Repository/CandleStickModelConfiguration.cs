using CandleStick.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandleStick.Infranstructure.Repository
{
    public class CandleStickModelConfiguration : IEntityTypeConfiguration<CandleStickModel>
    {
        public void Configure(EntityTypeBuilder<CandleStickModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.OpenPrice).IsRequired();
            builder.Property(x => x.ClosePrice).IsRequired();
            builder.Property(x => x.HighPrice).IsRequired();
            builder.Property(x => x.LowPrice).IsRequired();
            builder.Property(x => x.AveragePrice).IsRequired(false);
        }
    }
}
