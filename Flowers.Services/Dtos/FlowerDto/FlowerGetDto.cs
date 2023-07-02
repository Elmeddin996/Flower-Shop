using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Dtos.FlowerDto
{
    public class FlowerGetDto
    {
        public int CategorieId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Desc { get; set; }

        public  List<string> ImageNames { get; set; }
        public CategorieInFlowerDto Categorie { get; set; }
    }

    public class CategorieInFlowerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
