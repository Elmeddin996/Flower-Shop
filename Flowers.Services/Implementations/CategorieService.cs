using AutoMapper;
using Flowers.Core.Entities;
using Flowers.Core.Repositories;
using Flowers.Services.Dtos.CategorieDto;
using Flowers.Services.Dtos.Common;
using Flowers.Services.Exceptions;
using Flowers.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Implementations
{
    public class CategorieService : ICategorieService
    {
        private readonly ICategorieRepository _repository;
        private readonly IMapper _mapper;

        public CategorieService(ICategorieRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CreateEntityDto Create(CategoriePostDto dto)
        {
            if (_repository.IsExist(x => x.Name == dto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name is already exist");

            var entity = _mapper.Map<Categorie>(dto);

            _repository.Add(entity);
            _repository.Commit();

            return new CreateEntityDto { Id = entity.Id };
        }

        public void Delete(int id)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Entity not found");

            _repository.Remove(entity);
            _repository.Commit();
        }

        public void Edit(int id, CategoriePutDto dto)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Entity not found");

            if (entity.Name != dto.Name && _repository.IsExist(x => x.Name == dto.Name))
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name is already exist");

            entity.Name = dto.Name;
            _repository.Commit();
        }

        public List<CategorieGetAllDto> GetAll()
        {
            var entities = _repository.GetAll(x => true);

            return _mapper.Map<List<CategorieGetAllDto>>(entities);
        }

        public CategorieGetDto GetById(int id)
        {
            var entity = _repository.Get(x => x.Id == id);

            if (entity == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "Entity not found");

            return _mapper.Map<CategorieGetDto>(entity);
        }
    }
}
