using Microsoft.AspNetCore.Identity;
using SmartSchool.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Core.Entities
{
    public class Pupil : EntityObject
    {
        [Required]
        [MinLength(2, ErrorMessage = "The first name must be at least two characters long")]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The first name must be at least two characters long")]
        public string Lastname { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegisteredSince { get; set; }

        public string Name => $"{Lastname} {Firstname}";
        
    }
}
