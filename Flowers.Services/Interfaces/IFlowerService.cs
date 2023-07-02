using Flowers.Services.Dtos.Common;
using Flowers.Services.Dtos.FlowerDto;


namespace Flowers.Services.Interfaces
{
    public interface IFlowerService
    {
            CreateEntityDto Create(FlowerPostDto dto);
            void Edit(int id, FlowerPutDto dto);
            FlowerGetDto GetById(int id);
            List<FlowerGetAllDto> GetAll();
            void Delete(int id);
    }
}
