using SchoolLocker.Core.Entities;
using System;

namespace SchoolLocker.Web.DataTransferObjects
{
    public class PupilWithDetailsDto : PupilDto 
    {
        public bool IsAdmin { get; set; }
        public DateTime RegisteredSince { get; set; }
    }
}
