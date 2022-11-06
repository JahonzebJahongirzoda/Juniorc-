using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Dto;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<AddProduct> Create(AddProduct author)
        {
            return await _service.AddProduct(author);

        }

        [HttpGet]
        public async Task<List<GetProducts>> Get()

        {
            return await _service.GetProducts();
        }
        [HttpPut]
        public async Task<AddProduct> Put(AddProduct author)

        {
            return await _service.UpdateProduct(author);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)

        {
            return await _service.DeleteProduct(id);
        }




    }
}