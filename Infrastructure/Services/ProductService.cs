using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Dto;
namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddProduct> AddProduct(AddProduct challengeDto)
    {
        var challenge = new Product
        {
            Name = challengeDto.Name,
            Price = challengeDto.Price
        };

        await _context.Products.AddAsync(challenge);
        await _context.SaveChangesAsync();

        challengeDto.Id = challenge.Id;

        var challengeCreated = await GetProductById(challenge.Id);
        return challengeCreated;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var challenge = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);

        if (challenge == null)
        {
            return false;
        }

        _context.Products.Remove(challenge);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetProducts>> GetProducts()
    {
        var challenges = await _context.Products
            .Select(l => new GetProducts
            {
                Id = l.Id,
                Price = l.Price,
                Name = l.Name
            }
        ).ToListAsync();
        return challenges;
    }

    public async Task<AddProduct> GetProductById(int id)
    {
        var challenge = await _context.Products
            .Select(e => new AddProduct()
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        return challenge;
    }

    public async Task<AddProduct> UpdateProduct(AddProduct challengeDto)
    {
        var challenge = await _context.Products.FirstOrDefaultAsync(e => e.Id == challengeDto.Id);

        if (challenge == null)
        {
            return null;
        }

        challenge.Name = challengeDto.Name;
        challenge.Price = challengeDto.Price;

        await _context.SaveChangesAsync();

        var challengeUpdated = await GetProductById(challenge.Id);
        return challengeUpdated;
    }
}