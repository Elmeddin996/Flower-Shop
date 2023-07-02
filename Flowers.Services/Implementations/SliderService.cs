using AutoMapper;
using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using Flowers.Services.Dtos.Common;
using Flowers.Services.Dtos.SliderDto;
using Flowers.Services.Exceptions;
using Flowers.Services.Helpers;
using Flowers.Services.Interfaces;


namespace Flowers.Services.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _repository;
        private readonly IMapper _mapper;

        public SliderService(ISliderRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CreateEntityDto Create(SliderPostDto dto)
        {
            List<RestExceptionError> errors = new List<RestExceptionError>();

            if (_repository.IsExist(x => x.Order == dto.Order))
                errors.Add(new RestExceptionError("Order", "Order is already exists"));

            if (errors.Count > 0) throw new RestException(System.Net.HttpStatusCode.BadRequest, errors);

            var entity = _mapper.Map<Slider>(dto);

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            entity.ImageName = FileManager.Save(dto.ImageFile, rootPath, "uploads/sliders");

            _repository.Add(entity);
            _repository.Commit();

            return new CreateEntityDto { Id = entity.Id };

        }

        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Slider not found");

            _repository.Remove(entity);
            _repository.Commit();

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            FileManager.Delete(rootPath, "uploads/sliders", entity.ImageName);
        }

        public void Edit(int id, SliderPutDto dto)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Slider not found");

            List<RestExceptionError> errors = new List<RestExceptionError>();

            if (dto.Order != entity.Order && _repository.IsExist(x => x.Order == dto.Order))
                errors.Add(new RestExceptionError("Order", "Order is already exists"));

            if (errors.Count > 0) throw new RestException(System.Net.HttpStatusCode.BadRequest, errors);

            entity.Order = dto.Order;
            entity.Desc = dto.Desc;
            entity.Title= dto.Title;

            string? removableFileName = null;
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";

            if (dto.ImageFile != null)
            {
                removableFileName = entity.ImageName;
                entity.ImageName = FileManager.Save(dto.ImageFile, rootPath, "uploads/sliders");
            }

            _repository.Commit();

            if (removableFileName != null) FileManager.Delete(rootPath, "uploads/sliders", removableFileName);
        }

        public List<SliderGetAllDto> GetAll()
        {
            var entities = _repository.GetAll(x => true);

            return _mapper.Map<List<SliderGetAllDto>>(entities);
        }

        public SliderGetDto GetById(int id)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Slider", "Slider not found");

            return _mapper.Map<SliderGetDto>(entity);
        }
    }
}
