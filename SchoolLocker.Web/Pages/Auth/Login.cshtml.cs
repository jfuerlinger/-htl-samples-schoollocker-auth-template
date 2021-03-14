using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;

namespace SchoolLocker.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public CredentialDto Credentials { get; set; }

        public IActionResult OnPostAsync()
        {
            return Page();
        }
    }
}
