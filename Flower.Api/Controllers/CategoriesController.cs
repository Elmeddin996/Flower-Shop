using Flowers.Services.Dtos.CategorieDto;
using Flowers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Flowers.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieService _service;

        public CategoriesController(ICategorieService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public IActionResult Create(CategoriePostDto postDto)
        {
            var result = _service.Create(postDto);
            return StatusCode(201, result);
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, CategoriePutDto putDto)
        {
            _service.Edit(id, putDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<List<CategorieGetAllDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }


        [HttpGet("{id}")]
        public ActionResult<CategorieGetDto> Get(int id)
        {
            return Ok(_service.GetById(id));
        }

    }
}
