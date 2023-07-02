using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flowers.Core.Entities;

namespace Flowers.Data.Configurations
{
    internal class FlowerConfig : IEntityTypeConfiguration<Flower>
    {
        public void Configure(EntityTypeBuilder<Flower> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.SalePrice).HasColumnType("money");
            builder.Property(x => x.CostPrice).HasColumnType("money");
        }
    }
}
