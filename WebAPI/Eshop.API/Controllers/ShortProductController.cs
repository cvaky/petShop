using System.Threading.Tasks;
using Eshop.Domain.Domain;
using Eshop.Domain.Service;
using Eshop.Entity.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortProductController : ControllerBase
    {
        private readonly ShortProductService<ShortProductViewModel, Product> _shortProductService;
        public ShortProductController(ShortProductService<ShortProductViewModel, Product> shortProductService)
        {
            _shortProductService = shortProductService;
        }

        // GET api/values/5
        [ProducesResponseType(typeof(ShortProductViewModel[]), 200)]
        [HttpGet("animalCategoryId")]
        public async Task<IActionResult> GetByCategory([FromQuery]int? animalCategoryId = null)
        {
            var items = animalCategoryId != null ? await _shortProductService.Get(x => x.AnimalCategoryId == animalCategoryId) : await _shortProductService.GetAll();
            return Ok(items);
        }
    }
}

