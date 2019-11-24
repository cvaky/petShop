using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Domain.Domain;
using Eshop.Domain.Service;
using Eshop.Entity.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalCategoryController : ControllerBase
    {
        private readonly AnimalCategoryService<AnimalCategoryViewModel, AnimalCategory> _animalCategoryService;
        public AnimalCategoryController(AnimalCategoryService<AnimalCategoryViewModel, AnimalCategory> animalCategoryService)
        {
            _animalCategoryService = animalCategoryService;
        }
        // GET api/values
        [ProducesResponseType(typeof(AnimalCategoryViewModel[]), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _animalCategoryService.GetAll();
            return Ok(items);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // GET api/values/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(AnimalCategoryViewModel), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _animalCategoryService.GetSingle(id, null);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AnimalCategoryViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var id = await _animalCategoryService.Add(product);
            return Created($"api/AnimalCategory/{id}", id);
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] AnimalCategoryViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var id = await _animalCategoryService.Update(product);
            if (id == 0)
            {
                return StatusCode(304);
            }
            else if (id == -1)
            {
                return StatusCode(412, "DbUpdateConcurrencyException");
            }
            else
            {
                return Accepted($"api/AnimalCategory/{id}", id);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respond = await _animalCategoryService.Remove(id);
            if (respond == 0)
            {
                return NotFound();
            }
            else if (respond == -1)
            {
                return StatusCode(412, "DbUpdateConcurrencyException");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
