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
        [HttpGet("{animalCategoryId}")]
        public async Task<IActionResult> GetByCategory(int animalCategoryId)
        {
            var items = await _shortProductService.Get(x => x.AnimalCategoryId == animalCategoryId);
            return Ok(items);
        }
    }
}

