using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Data.Repositories
{
    public class CategorieRepository:Repository<Categorie>,ICategorieRepository
    {
        public CategorieRepository(FlowerDbContext context):base(context)
        {
            
        }
    }
}
