using Microsoft.AspNetCore.Mvc;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Mongo.Entities;

namespace TripsApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T, U> : Controller where T : class where U : Entity
    {
        private readonly IBaseService<T, U> _baseService;

        public BaseController(IBaseService<T, U> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _baseService.ListAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _baseService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] T t)
        {
            var result = await _baseService.SaveAsync(t);

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] T t)
        {
            var result = await _baseService.UpdateAsync(t);

            return Ok(result);
        }
    }
}
