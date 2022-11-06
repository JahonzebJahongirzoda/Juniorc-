
using Domain.Entities;
namespace Infrastructure.Services;
using Domain.Dto;
public interface ICustomerPurchacesService
{
    Task<AddCustomerPurchaces> AddCustomerPurchace(AddCustomerPurchaces challengeDto);
    Task<bool> DeleteCustomerPurchace(int id);
    Task<List<GetCustomerPurchaces>> GetCustomerPurchaces();
    Task<AddCustomerPurchaces> GetCustomerPurchaceById(int id);
    Task<AddCustomerPurchaces> UpdateCustomerPurchace(AddCustomerPurchaces customerpsdto);

}