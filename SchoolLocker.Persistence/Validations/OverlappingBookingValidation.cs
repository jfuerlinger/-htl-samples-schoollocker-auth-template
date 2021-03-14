using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SchoolLocker.Persistence.Validations
{
    public class OverlappingBookingValidation : ValidationAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        public Booking OverlappingBooking { get; set; }

        public OverlappingBookingValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is Booking booking))
            {
                throw new ArgumentException("Value is not a booking");
            }

            OverlappingBooking = _unitOfWork.BookingRepository.GetOverlappingBookingAsync(booking).Result;
            if (OverlappingBooking != null)
            {
                if (OverlappingBooking.To == null)
                {
                    return new ValidationResult("Es existiert bereits eine Buchung mit offenem Ende zur fraglichen Zeit", new[] { nameof(Booking.From) });
                }

                return new ValidationResult("Es existiert bereits eine Buchung zur fraglichen Zeit", new[] { nameof(Booking.From) });
            }

            return ValidationResult.Success;
        }
    }
}
