using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolLocker.Persistence
{
    internal class PupilRepository : IPupilRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PupilRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Pupil[]> GetAllAsync()
            => await _dbContext
                .Pupils
                .OrderBy(p => p.Lastname)
                .ThenBy(p => p.Firstname)
                .ToArrayAsync();


        public Task AddAsync(Pupil pupil)
            => throw new NotImplementedException();

        public async Task<Pupil> GetByIdAsync(int id)
            => await _dbContext
                .Pupils
                .FindAsync(id);

        public void Delete(Pupil pupil)
            => _dbContext
                .Pupils
                .Remove(pupil);
    }
}