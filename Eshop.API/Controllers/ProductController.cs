﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service;
using Eshop.Entity.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService<ProductViewModel, Product> _productService;
        public ProductController(ProductService<ProductViewModel, Product> productService, IMapper mapper)
        {
            _productService = productService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _productService.GetAll();
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _productService.GetSingle(id);
            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var id = await _productService.Add(product);
            return Created($"api/Product/{id}", id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProductViewModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var id = await _productService.Update(product);
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
                return Accepted($"api/Product/{id}", id);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respond = await _productService.Remove(id);
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
