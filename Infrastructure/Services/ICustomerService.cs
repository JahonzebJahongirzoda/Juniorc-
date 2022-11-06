
using Domain.Entities;
namespace Infrastructure.Services;
using Domain.Dto;
public interface ICustomerService
{
    Task<AddCustomer> AddCustomer(AddCustomer challengeDto);
    Task<bool> DeleteCustomer(int id);
    Task<List<GetCustomers>> GetCustomers();
    Task<AddCustomer> GetCustomerById(int id);
    Task<AddCustomer> UpdateCustomer(AddCustomer challengeDto);

}