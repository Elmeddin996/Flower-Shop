using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Data.Repositories
{
    public class SliderRepository:Repository<Slider>,ISliderRepository
    {
        public SliderRepository(FlowerDbContext context):base(context)
        {
        }
    }
}
