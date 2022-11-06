using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
namespace Infrastructure.Services;
using Domain.Dto;
public class InstallmentService : IInstallmentService
{
    private readonly DataContext _context;
    public InstallmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<AddInstallment> AddInstallment(AddInstallment challengeDto)
    {
        var challenge = new Installment
        {
            Installments = challengeDto.Installments,
            Percentage = challengeDto.Percentage
        };

        await _context.Installments.AddAsync(challenge);
        await _context.SaveChangesAsync();

        challengeDto.Id = challenge.Id;

        var challengeCreated = await GetInstallmentById(challenge.Id);
        return challengeCreated;
    }

    public async Task<bool> DeleteInstallment(int id)
    {
        var challenge = await _context.Installments.FirstOrDefaultAsync(e => e.Id == id);

        if (challenge == null)
        {
            return false;
        }

        _context.Installments.Remove(challenge);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<GetInstallments>> GetInstallments()
    {
        var challenges = await _context.Installments
            .Select(l => new GetInstallments
            {
                Id = l.Id,
                Installments = l.Installments,
                Percentage = l.Percentage
            }
        ).ToListAsync();
        return challenges;
    }

    public async Task<AddInstallment> GetInstallmentById(int id)
    {
        var challenge = await _context.Installments
            .Select(e => new AddInstallment()
            {
                Id = e.Id,
                Installments = e.Installments,
                Percentage = e.Percentage
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        return challenge;
    }

    public async Task<AddInstallment> UpdateInstallment(AddInstallment challengeDto)
    {
        var challenge = await _context.Installments.FirstOrDefaultAsync(e => e.Id == challengeDto.Id);

        if (challenge == null)
        {
            return null;
        }

        challenge.Installments = challengeDto.Installments;
        challenge.Percentage = challengeDto.Percentage;

        await _context.SaveChangesAsync();

        var challengeUpdated = await GetInstallmentById(challenge.Id);
        return challengeUpdated;
    }
}