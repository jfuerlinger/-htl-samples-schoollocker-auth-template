using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Web.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public Task<ActionResult> OnPostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
