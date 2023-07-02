using Flowers.Services.Dtos.Common;
using Flowers.Services.Dtos.SliderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Interfaces
{
    public interface ISliderService
    {
        CreateEntityDto Create(SliderPostDto dto);
        void Edit(int id, SliderPutDto dto);
        List<SliderGetAllDto> GetAll();
        SliderGetDto GetById(int id);
        void Delete(int id);
    }
}
