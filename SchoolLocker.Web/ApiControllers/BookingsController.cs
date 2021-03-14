using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Linq;
using SchoolLocker.Core.DataTransferObjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SchoolLocker.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Pupil> _userManager;

        public BookingsController(
            IUnitOfWork unitOfWork,
            UserManager<Pupil> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        /// <summary>
        /// Lists all overlapping bookings
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Not allowed</response>
        /// <response code="404">No locker found</response>
        // GET: api/Bookings/110;2019-03-28;2019-04-15
        [HttpGet("GetOverlappingBookings")]
        public async Task<ActionResult<BookingDto[]>> GetOverlappingBookings(int lockerNumber, DateTime from, DateTime to)
        {
            if (await _unitOfWork
                    .LockerRepository
                    .GetByLockerNrAsync(lockerNumber) == null)
            {
                return NotFound();
            }

            var bookings = await _unitOfWork.BookingRepository.GetOverlappingBookingsAsync(lockerNumber, from, to);
            return bookings;
            // 2020-07-01  2020-07-20  ==> 0
            // 2020-07-01  2020-07-21  ==> 1
            // 2020-06-29  2020-07-20  ==> 1
            // 2020-07-20  2020-08-08  ==> 1
            // 2019-10-21  2020-09-03  ==> 3
            // 2020-06-29  2020-08-16  ==> 3
        }

        /// <summary>
        /// Lists all bookings of the current user
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet("Mine")]
        public async Task<ActionResult<BookingDto[]>> GetMyBookings()
        {
            throw new NotImplementedException();
        }
    }
}