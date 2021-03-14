using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLocker.Web.Pages.Pupils
{
    public class IndexModel : PageModel
    {
        public PupilWithDetailsDto[] Pupils { get; set; }

        public ActionResult OnGetAsync()
        {
            return Page();
        }
    }
}
