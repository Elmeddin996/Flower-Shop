using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Data.Repositories
{
    public class FlowerRepository:Repository<Flower>,IFlowerRepository
    {
        public FlowerRepository(FlowerDbContext context):base(context)
        {
        }
    }
}
