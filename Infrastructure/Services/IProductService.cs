
using Domain.Entities;
namespace Infrastructure.Services;
using Domain.Dto;
public interface IProductService
{
    Task<AddProduct> AddProduct(AddProduct challengeDto);
    Task<bool> DeleteProduct(int id);
    Task<List<GetProducts>> GetProducts();
    Task<AddProduct> GetProductById(int id);
    Task<AddProduct> UpdateProduct(AddProduct challengeDto);

}