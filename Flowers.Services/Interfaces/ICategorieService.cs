using Flowers.Services.Dtos.CategorieDto;
using Flowers.Services.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Services.Interfaces
{
    public interface ICategorieService
    {
        CreateEntityDto Create(CategoriePostDto dto);
        void Edit(int id, CategoriePutDto dto);
        List<CategorieGetAllDto> GetAll();
        CategorieGetDto GetById(int id);
        void Delete(int id);
    }
}
