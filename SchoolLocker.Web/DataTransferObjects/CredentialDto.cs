using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolLocker.Web.DataTransferObjects
{
    public class CredentialDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
