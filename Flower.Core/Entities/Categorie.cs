using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Core.Entities
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Flower> Flower { get; set; } = new List<Flower>();
    }
}
