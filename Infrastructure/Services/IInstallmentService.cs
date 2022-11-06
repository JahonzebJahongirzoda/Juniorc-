
using Domain.Entities;
namespace Infrastructure.Services;
using Domain.Dto;
public interface IInstallmentService
{
    Task<AddInstallment> AddInstallment(AddInstallment challengeDto);
    Task<bool> DeleteInstallment(int id);
    Task<List<GetInstallments>> GetInstallments();
    Task<AddInstallment> GetInstallmentById(int id);
    Task<AddInstallment> UpdateInstallment(AddInstallment challengeDto);

}