using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Core.Entities
{
    public class FlowerImage
    {
        public int Id { get; set; }
        public int FlowerId { get; set; }
        public string ImageName { get; set; }
        public bool PosterStatus { get; set; }

        public Flower Flower { get; set; }
    }
}
