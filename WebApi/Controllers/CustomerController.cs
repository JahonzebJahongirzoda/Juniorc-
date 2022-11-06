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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<AddCustomer> Create(AddCustomer author)
        {
            return await _service.AddCustomer(author);

        }

        [HttpGet]
        public async Task<List<GetCustomers>> Get()

        {
            return await _service.GetCustomers();
        }
        [HttpPut]
        public async Task<AddCustomer> Put(AddCustomer author)

        {
            return await _service.UpdateCustomer(author);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)

        {
            return await _service.DeleteCustomer(id);
        }




    }
}