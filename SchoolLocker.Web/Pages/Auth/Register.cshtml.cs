using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;

namespace SchoolLocker.Web.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserDto AuthUser { get; set; }

        public ActionResult OnPostAsync()
        {
            return Page();
        }
    }
}
