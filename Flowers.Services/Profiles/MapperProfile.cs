using AutoMapper;
using Flowers.Core.Entities;
using Flowers.Services.Dtos.CategorieDto;
using Flowers.Services.Dtos.FlowerDto;
using Flowers.Services.Dtos.SliderDto;
using Microsoft.AspNetCore.Http;


namespace Flowers.Services.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile(IHttpContextAccessor accessor)
        {

            CreateMap<Flower, FlowerGetDto>();
            CreateMap<FlowerPostDto, Flower>();
            CreateMap<Flower, FlowerGetAllDto>();
            CreateMap<Flower, FlowerPutDto>();
            CreateMap<FlowerPutDto, Flower > ();


            CreateMap<CategoriePostDto, Categorie>();
            CreateMap<CategoriePutDto, Categorie>();
            CreateMap<Categorie, CategorieGetAllDto>();
            CreateMap<Categorie, CategorieInFlowerDto>();
            CreateMap<Categorie, CategorieGetDto>();

            CreateMap<SliderPostDto, Slider>();
            CreateMap<SliderPutDto, Slider>();
            CreateMap<Slider, SliderGetAllDto>();
            CreateMap<Slider, SliderGetDto>();

        }
    }
}
