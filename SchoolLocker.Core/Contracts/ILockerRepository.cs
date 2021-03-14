using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
    public interface ILockerRepository
    {
        Task<SchoolLockerOverviewDto[]> GetLockersOverviewAsync();
        Task<Locker> GetByIdAsync(int lockerId);
        Task<SchoolLockerDto[]> GetLockersWithStateAsync();
        Task AddAsync(Locker locker);
        Task<bool> HasDuplicateAsync(Locker locker);
        Task<int[]> GetLockerNumbersAsync();
        Task<Locker> GetByLockerNrAsync(int lockerNr);
        Task<Locker> GetByLockerNrWithBookingsAsync(int lockerNr);
        Task DeleteByLockerNrAsync(int lockerNr);
    }
}
