using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Dto;
namespace Infrastructure.Services;

public class CustomerPurchaceService : ICustomerPurchacesService
{
    private readonly DataContext _context;
    public CustomerPurchaceService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddCustomerPurchaces> AddCustomerPurchace(AddCustomerPurchaces customerdto)
    {
        var customer = new CustomerPurchaces
        {
            CustomerId = customerdto.CustomerId,
            InstallmentId = customerdto.InstallmentId
        };

        await _context.CustomerPurchaces.AddAsync(customer);
        await _context.SaveChangesAsync();

        customerdto.Id = customer.Id;

        var custometpurchaseCreated = await GetCustomerPurchaceById(customer.Id);
        return custometpurchaseCreated;
    }

    public async Task<bool> DeleteCustomerPurchace(int id)
    {
        var custometp = await _context.CustomerPurchaces.FirstOrDefaultAsync(e => e.Id == id);

        if (custometp == null)
        {
            return false;
        }

        _context.CustomerPurchaces.Remove(custometp);
        await _context.SaveChangesAsync();

        return true;
    }



    public async Task<List<GetCustomerPurchaces>> GetCustomerPurchaces()
    {
        var custometps = await _context.CustomerPurchaces
            .Select(l => new GetCustomerPurchaces
            {
                Id = l.Id,
                CustomerId = l.CustomerId,
                InstallmentId = l.InstallmentId
            }
        ).ToListAsync();
        return custometps;
    }

    public async Task<AddCustomerPurchaces> GetCustomerPurchaceById(int id)
    {
        var customerp = await _context.CustomerPurchaces
            .Select(e => new AddCustomerPurchaces()
            {
                Id = e.Id,
                CustomerId = e.CustomerId,
                InstallmentId = e.InstallmentId
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        return customerp;
    }

    public async Task<AddCustomerPurchaces> UpdateCustomerPurchace(AddCustomerPurchaces customerpsdto)
    {
        var customerp = await _context.CustomerPurchaces.FirstOrDefaultAsync(e => e.Id == customerpsdto.Id);

        if (customerp == null)
        {
            return null;
        }

        customerp.CustomerId = customerpsdto.CustomerId;
        customerp.InstallmentId = customerpsdto.InstallmentId;

        await _context.SaveChangesAsync();

        var challengeUpdated = await GetCustomerPurchaceById(customerp.Id);
        return challengeUpdated;
    }
}