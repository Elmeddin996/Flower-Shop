using AutoMapper;
using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using Flowers.Services.Dtos.Common;
using Flowers.Services.Dtos.FlowerDto;
using Flowers.Services.Exceptions;
using Flowers.Services.Helpers;
using Flowers.Services.Interfaces;

namespace Flowers.Services.Implementations
{
    public class FlowerService : IFlowerService
    {
        private readonly IFlowerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICategorieRepository _categorieRepo;

        public FlowerService(IFlowerRepository repository, IMapper mapper, ICategorieRepository  categorieRepo)
        {
            _repository = repository;
            _mapper = mapper;
            _categorieRepo = categorieRepo;
        }

        public CreateEntityDto Create(FlowerPostDto dto)
        {
            List<RestExceptionError> errors = new List<RestExceptionError>();

            if (!_categorieRepo.IsExist(x => x.Id == dto.CategorieId))
                errors.Add(new RestExceptionError("CategorieId", "CategorieId is not correct"));

            if (_repository.IsExist(x => x.Name == dto.Name))
                errors.Add(new RestExceptionError("Name", "Name is already exists"));

            if (errors.Count > 0) throw new RestException(System.Net.HttpStatusCode.BadRequest, errors);

            var entity = _mapper.Map<Flower>(dto);

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";

            FlowerImage poster = new FlowerImage
            {
                ImageName = FileManager.Save(dto.PosterImageFile, rootPath, "uploads/flowers"),
                PosterStatus = true
            };
            
            entity.FlowerImages.Add(poster);

            foreach (var img in dto.ImageFiles)
            {
                FlowerImage image = new FlowerImage
                {
                    ImageName = FileManager.Save(img, rootPath, "uploads/flowers"),
                    PosterStatus = false
                };
                entity.FlowerImages.Add(image);
            }

            _repository.Add(entity);
            _repository.Commit();

            return new CreateEntityDto { Id = entity.Id };
        }


        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.Id == id, "FlowerImages");

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Flower not found");

            _repository.Remove(entity);
            _repository.Commit();

            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";
            
            foreach (var img in entity.FlowerImages)
            {
                FileManager.Delete(rootPath, "uploads/flowers", img.ImageName);
            }
        }

        public void Edit(int id, FlowerPutDto dto)
        {
            var entity = _repository.Get(x => x.Id == id,"FlowerImages");

            List<RestExceptionError> errors = new List<RestExceptionError>();

            if (!_repository.IsExist(x => x.Id == dto.CategorieId))
                errors.Add(new RestExceptionError("CategorieId", "CategorieId is not correct"));

            if (_repository.IsExist(x => x.Name == dto.Name))
                errors.Add(new RestExceptionError("Name", "Name is already exists"));

            if (errors.Count > 0) throw new RestException(System.Net.HttpStatusCode.BadRequest, errors);

            _repository.Add(_mapper.Map<Flower>(dto));


            string removableFileName = null;
            string rootPath = Directory.GetCurrentDirectory() + "/wwwroot";

            if (dto.PosterImageFile != null)
            {
                removableFileName = entity.FlowerImages.FirstOrDefault(x=>x.PosterStatus==true).ImageName;
                entity.FlowerImages.FirstOrDefault(x => x.PosterStatus == true).ImageName = FileManager.Save(dto.PosterImageFile, rootPath, "uploads/flowers");
            }
            if (removableFileName != null) FileManager.Delete(rootPath, "uploads/flowers", removableFileName);

            if (dto.ImageFiles!=null)
            {
                 removableFileName = entity.FlowerImages.Where(x=>x.PosterStatus==false).ToList().ToString();
                foreach (var img in dto.ImageFiles)
                {
                    entity.FlowerImages.FirstOrDefault(x => x.PosterStatus == false).ImageName = FileManager.Save(img, rootPath, "uploads/flowers");
                    if (removableFileName !=null) FileManager.Delete(rootPath, "uploads/flowers", removableFileName);
                }
            }
            _repository.Commit();
        }

        public List<FlowerGetAllDto> GetAll()
        {
            var entities = _repository.GetAll(x => true, "FlowerImages");


            var dtos = _mapper.Map<List<FlowerGetAllDto>>(entities);

            foreach (var dto in dtos)
            {
                var flowerImages = entities.FirstOrDefault(e => e.Id == dto.Id)?.FlowerImages;
                dto.ImageName = flowerImages?.FirstOrDefault()?.ImageName;
            }


            return dtos;
        }

        public FlowerGetDto GetById(int id)
        {
            var entity = _repository.Get(x => x.Id == id, "FlowerImages", "Categorie");

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Flower not found");

            var dto = _mapper.Map<FlowerGetDto>(entity);
            dto.ImageNames = entity.FlowerImages?.Select(image => image.ImageName).ToList();

            return dto;
        }
    }
}
