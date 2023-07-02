using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Dtos.SliderDto
{
    public class SliderGetDto
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
    }
}
