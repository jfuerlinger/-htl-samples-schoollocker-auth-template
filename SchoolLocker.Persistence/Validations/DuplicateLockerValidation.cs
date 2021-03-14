using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Persistence.Validations
{
    public class DuplicateLockerValidation : ValidationAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        public DuplicateLockerValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is Locker locker))
            {
                throw new ArgumentException("Value is not a locker", nameof(value));
            }

            if (_unitOfWork.LockerRepository.HasDuplicateAsync(locker).Result)
            {
                return new ValidationResult("Es existiert bereits ein Fach mit der Nummer");
            }
            return ValidationResult.Success;
        }
    }
}
