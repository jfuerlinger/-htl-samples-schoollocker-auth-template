using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SchoolLocker.Persistence
{
    internal class LockerRepository : ILockerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LockerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HasDuplicateAsync(Locker locker)
            => await _dbContext.Lockers.AnyAsync(l => l.Id != locker.Id && l.Number == locker.Number);

        public async Task<int[]> GetLockerNumbersAsync()
            => await _dbContext
                .Lockers
                .Select(locker => locker.Number)
                .OrderBy(nr => nr)
                .ToArrayAsync();

        public async Task<Locker> GetByLockerNrAsync(int lockerNr)
            => await _dbContext
                .Lockers
                .SingleOrDefaultAsync(l => l.Number == lockerNr);

        public async Task<Locker> GetByLockerNrWithBookingsAsync(int lockerNr)
            => await _dbContext
                .Lockers
                .Include(l => l.Bookings)
                .SingleOrDefaultAsync(l => l.Number == lockerNr);

        public async Task DeleteByLockerNrAsync(int lockerNr)
        {
            var locker = await GetByLockerNrAsync(lockerNr);
            if (locker != null)
            {
                _dbContext
                    .Lockers
                    .Remove(locker);
            }
        }

        public async Task<SchoolLockerOverviewDto[]> GetLockersOverviewAsync()
        {
            var groupedBookings = (await _dbContext.Bookings
                .OrderByDescending(b => b.From)
                .Include(b => b.Locker)
                .ToArrayAsync())
                .GroupBy(b => b.Locker)
                .Select(group => new SchoolLockerOverviewDto()
                {
                    Locker = group.Key,
                    CountBookings = group.Count(),
                    From = group.First().From,
                    To = group.First().To
                })
                .OrderBy(dto => dto.Locker.Number)
                .ToList();

            var lockers = await _dbContext  // mit Locker ohne Bookings vereinen
                .Lockers
                .Where(l => l.Bookings.Count == 0)
                .Select(l => new SchoolLockerOverviewDto
                {
                    Locker = l,
                    CountBookings = 0,
                    From = null,
                    To = null
                })
                .ToListAsync();

            var union = groupedBookings
                .Union(lockers)
                .ToArray();


            return union;
        }

        public async Task<Locker> GetByIdAsync(int lockerId)
            => await _dbContext.Lockers.FindAsync(lockerId);

        public async Task<SchoolLockerDto[]> GetLockersWithStateAsync()
        {
            var lockers = await _dbContext
                .Lockers
                .Select(l => new SchoolLockerDto
                {
                    Number = l.Number,
                    CountBookings = l.Bookings.Count,
                    IsTodayFree = !l.Bookings.Any(b => (b.From <= DateTime.Today && b.To == null ||
                        b.From <= DateTime.Today && b.To >= DateTime.Today))
                })
                .OrderBy(l => l.Number)
                .ToArrayAsync();
            return lockers;
        }

        public async Task AddAsync(Locker locker)
            => await _dbContext.Lockers.AddAsync(locker);
    }
}