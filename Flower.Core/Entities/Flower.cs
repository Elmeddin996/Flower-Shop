using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Core.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        public int CategorieId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public string Desc { get; set; }


        public List<FlowerImage> FlowerImages { get; set; }= new List<FlowerImage>();
        public Categorie Categorie { get; set;}
    }
}
