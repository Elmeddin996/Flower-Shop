using Flowers.Services.Dtos.FlowerDto;
using Flowers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Flowers.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerService _service;

        public FlowersController(IFlowerService service)
        {
            _service = service;
        }


        [HttpPost("")]
        public IActionResult Create([FromForm]FlowerPostDto dto)
        {
            return StatusCode(201, _service.Create(dto));
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromForm]FlowerPutDto dto)
        {
            _service.Edit(id, dto);

            return NoContent();
        }

        [HttpGet("all")]
        public ActionResult<FlowerGetAllDto> GetAll() 
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            return Ok(_service.GetById(id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
