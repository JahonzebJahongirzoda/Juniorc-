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
    public class InstallmentController : ControllerBase
    {

        private readonly InstallmentService _service;

        public InstallmentController(InstallmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<AddInstallment> Create(AddInstallment author)
        {
            return await _service.AddInstallment(author);

        }

        [HttpGet]
        public async Task<List<GetInstallments>> Get()

        {
            return await _service.GetInstallments();
        }
        [HttpPut]
        public async Task<AddInstallment> Put(AddInstallment author)

        {
            return await _service.UpdateInstallment(author);
        }
        [HttpDelete]
        public async Task<bool> Delete(int id)

        {
            return await _service.DeleteInstallment(id);
        }




    }
}