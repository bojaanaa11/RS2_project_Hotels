using Microsoft.EntityFrameworkCore;
using Rating.Application.Contracts.Factories;
using Rating.Application.Contracts.Persistence;
using Rating.Application.Features.Ratings.Queries.ViewModels;
using Rating.Domain.Aggregates;
using Rating.Domain.Entities;
using Rating.Infrastructure.Persistence;

namespace Rating.Infrastructure.Repositories;

public class RatingProcessRepository  : RepositoryBase<RatingProcess>, IRatingProcessRepository
{
    private readonly IRatingProcessViewModelFactory _factory;
    public RatingProcessRepository(RatingContext dbContext, IRatingProcessViewModelFactory factory) : base(dbContext)
    {
        _factory = factory;
    }

    public async Task<RatingProcessViewModel> AddRatingProcess(string reservationId, string guestId, string hotelId,string hotelName)
    {
        RatingProcess process = new RatingProcess(hotelId,hotelName, reservationId, guestId, "Pending");
        var res=await _dbContext.RatingProcesses.AddAsync(process);
        await _dbContext.SaveChangesAsync();

        return _factory.CreateRatingProcessViewModel(res.Entity);
    }

    public async Task<bool> UpdateRatingProcess(string reservationId, string guestId,string hotelId,string hotelName, string status)
    {
        RatingProcess process = new RatingProcess(hotelId, hotelName,reservationId, guestId, status,null);
        _dbContext.Entry(process).State = EntityState.Modified;
        var res =await _dbContext.SaveChangesAsync();

        return res != 0;

    }

    public async Task<IReadOnlyCollection<RatingProcess>?> GetRatingProcesses(string guestId)
    {
        var res =await _dbContext.RatingProcesses.Where(o => o.GuestId == guestId && o.Status == "Pending").ToListAsync();
        return res;
    }
}