using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Web.DataTransferObjects
{
    public class PupilDto
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "The first name must be at least two characters long")]
        public string Firstname { get; set; }

        [MinLength(2, ErrorMessage = "The last name must be at least two characters long")]
        public string Lastname { get; set; }

        [EmailAddress]
        public string Username { get; set; }

        public string Name => $"{Lastname} {Firstname}";
    }
}
