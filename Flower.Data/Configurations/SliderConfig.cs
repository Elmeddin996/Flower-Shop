using Flowers.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Data.Configurations
{
    internal class SliderConfig : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(20).IsRequired(false);
            builder.Property(x => x.Desc).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.ImageName).HasMaxLength(100).IsRequired(true);
        }
    }
}
