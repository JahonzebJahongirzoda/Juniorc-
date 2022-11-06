using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Dto;
namespace Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly DataContext _context;
    public CustomerService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddCustomer> AddCustomer(AddCustomer challengeDto)
    {
        var challenge = new Customer
        {
            Name = challengeDto.Name,
            PhoneNumber = challengeDto.PhoneNumber
        };

        await _context.Customers.AddAsync(challenge);
        await _context.SaveChangesAsync();

        challengeDto.Id = challenge.Id;

        var challengeCreated = await GetCustomerById(challenge.Id);
        return challengeCreated;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var challenge = await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);

        if (challenge == null)
        {
            return false;
        }

        _context.Customers.Remove(challenge);
        await _context.SaveChangesAsync();

        return true;
    }



    public async Task<List<GetCustomers>> GetCustomers()
    {
        var challenges = await _context.Customers
            .Select(l => new GetCustomers
            {
                Id = l.Id,
                PhoneNumber = l.PhoneNumber,
                Name = l.Name
            }
        ).ToListAsync();
        return challenges;
    }
    public async Task<AddCustomer> GetCustomerById(int id)
    {
        var challenge = await _context.Customers
            .Select(e => new AddCustomer()
            {
                Id = e.Id,
                Name = e.Name,
                PhoneNumber = e.PhoneNumber
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        return challenge;
    }

    public async Task<AddCustomer> UpdateCustomer(AddCustomer challengeDto)
    {
        var challenge = await _context.Customers.FirstOrDefaultAsync(e => e.Id == challengeDto.Id);

        if (challenge == null)
        {
            return null;
        }

        challenge.Name = challengeDto.Name;
        challenge.PhoneNumber = challengeDto.PhoneNumber;

        await _context.SaveChangesAsync();

        var challengeUpdated = await GetCustomerById(challenge.Id);
        return challengeUpdated;
    }
}