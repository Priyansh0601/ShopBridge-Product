using Microsoft.AspNetCore.Mvc;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IRepository<Product, ProductAddDto, ProductUpdateDto, ProductDetailsDto> _repository;
        public ProductsController(IRepository<Product, ProductAddDto, ProductUpdateDto, ProductDetailsDto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetItems()
        {
            var products = await _repository.GetAll();
            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsDto>> GetById(int id)
        {
            var result= await _repository.GetSingle(id);
            if(result==null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ProductAddDto item)
        {
            try
            {
                if (item.Price < 0)
                return BadRequest("Item Price should not be less than 0");
                var id=  await _repository.Add(item);
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ProductUpdateDto item)
        {
            try
            {
                var result = await _repository.Update(item);
                if (result)
                    return Ok("Record Updated");
                else
                    return NotFound("No Record is found with entered id");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem(int Id)
        {
            try
            {
                var result = await _repository.Delete(Id);
                if (result)
                    return Ok("Record Deleted");
                else
                    return NotFound("No Record is found with entered id");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
