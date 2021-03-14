using SchoolLocker.Core.Entities;
using System;
using SchoolLocker.Core.DataTransferObjects;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts
{
    public interface IBookingRepository
    {
        Task AddRangeAsync(Booking[] bookings);
        Task AddAsync(Booking booking);

        Task<Booking> GetOverlappingBookingAsync(Booking booking);
        Task<BookingDto[]> GetOverlappingBookingsAsync(int lockerNumber, DateTime @from, DateTime? to);
    }
}
