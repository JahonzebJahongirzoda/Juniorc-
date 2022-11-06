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
    public class CustomerPurchaceController : ControllerBase
    {
        private readonly CustomerPurchaceService _service;

        public CustomerPurchaceController(CustomerPurchaceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<AddCustomerPurchaces> Create(AddCustomerPurchaces author)
        {
            return await _service.AddCustomerPurchace(author);

        }

        [HttpGet]
        public async Task<List<GetCustomerPurchaces>> Get()

        {
            return await _service.GetCustomerPurchaces();
        }
        [HttpPut]
        public async Task<AddCustomerPurchaces> Put(AddCustomerPurchaces author)

        {
            return await _service.UpdateCustomerPurchace(author);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)

        {
            return await _service.DeleteCustomerPurchace(id);
        }




    }
}