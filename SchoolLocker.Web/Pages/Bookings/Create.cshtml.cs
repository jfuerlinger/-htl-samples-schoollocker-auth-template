using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLocker.Web.Pages.Bookings
{
    public class LockerBookingModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Booking Booking { get; set; }

        [BindProperty]
        public string CurrentUsersName { get; set; }

        public LockerBookingModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGetAsync(int id)
        {
            // TODO: Daten initialisieren
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (ModelState.IsValid)
            {
                var pupil = await _unitOfWork
                    .PupilRepository
                    .GetByIdAsync(Booking.PupilId);
                if (pupil == null)
                {
                    return NotFound();
                }

                var locker = await _unitOfWork
                    .LockerRepository
                    .GetByIdAsync(Booking.LockerId);

                if (locker == null)
                {
                    return NotFound();
                }

                Booking newBooking = new()
                {
                    LockerId = locker.Id,
                    PupilId = pupil.Id,
                    From = Booking.From,
                    To = Booking.To
                };

                await _unitOfWork.BookingRepository.AddAsync(newBooking);
                try
                {
                    await _unitOfWork.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError("", valResult.ErrorMessage);
                }
            }

            return Page();
        }
    }
}