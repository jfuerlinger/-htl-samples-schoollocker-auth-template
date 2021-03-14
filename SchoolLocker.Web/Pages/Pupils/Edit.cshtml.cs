using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Entities;
using SchoolLocker.Web.DataTransferObjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SchoolLocker.Web.Pages.Pupils
{
    public class EditModel : PageModel
    {
        private readonly UserManager<Pupil> _userManager;

        public EditModel(UserManager<Pupil> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public PupilWithDetailsDto Pupil { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            // TODO

            return RedirectToPage("./Index");
        }
    }
}
