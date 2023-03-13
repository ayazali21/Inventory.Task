using System;
using System.Net.Http.Headers;
using Azure.Core;
using InventoryAPI.ApiModels;
using InventoryCore.Entity;
using InventoryCore.Enum;
using InventoryCore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
	public class InventoryController : BaseApiController
    {
        private readonly IRepository _repository;

        public InventoryController(IRepository repository)
		{
            _repository = repository;
        }

        [HttpGet("ProductCountBasedOnStatus/{status}")]
        public async Task<ActionResult> ProductCountBasedOnStatus(ProductStatus status)
        {
            try
            {
                int count = _repository.List<Product>().Where(t => t.Status == status).Count();
                return Ok(count);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("ChangeStatus/{id:int}/{status}")]
        public IActionResult ChangeStatus(int id, ProductStatus status)
        {
            try
            {
                var product = _repository.GetById<Product>(id);
                //validation
                if(product == null)
                    return NotFound("Product not found");
                product.ChangeStatus(status);
                _repository.Update(product);
                return Ok(ProductDTO.FromProduct(product));

            }
            catch {
                return BadRequest();
            }

        }

        [HttpPatch("{id:int}/SellProduct")]
        public IActionResult SellProduct(int id)
        {
            try
            {
                var product = _repository.GetById<Product>(id);
                
                //validation
                if (product == null)
                    return NotFound("Product not found");
                else if (product.IsSold())
                    return BadRequest("Product already sold");

                product.MarkAsSold();
                _repository.Update(product);
                return Ok(ProductDTO.FromProduct(product));

            }
            catch
            {
                return BadRequest();
            }

        }
    }
}

