using System;
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
    public class OrderController : ControllerBase
    {
        private readonly OrderService<OrderViewModel, Order> _orderService;
        public OrderController(OrderService<OrderViewModel, Order> orderService)
        {
            _orderService = orderService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // GET api/values
        [ProducesResponseType(typeof(OrderViewModel[]), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _orderService.GetAll();
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderViewModel), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _orderService.GetSingle(id, x => x.Product);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/values
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderViewModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            order.TimeStamp = DateTime.UtcNow;
            var id = await _orderService.Add(order);
            return Created($"api/Order/{id}", id);
        }


        // PUT api/values/5
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] OrderViewModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var id = await _orderService.Update(order);
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
                return Accepted($"api/Order/{id}", id);
            }
        }

        // DELETE api/values/5
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respond = await _orderService.Remove(id);
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
