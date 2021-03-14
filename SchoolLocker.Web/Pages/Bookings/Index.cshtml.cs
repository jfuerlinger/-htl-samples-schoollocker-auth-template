using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Web.Pages.Bookings
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SchoolLockerOverviewDto[] SchoolLockerOverviewDtos { get; set; }
        public BookingDto[] Bookings { get; set; }

        public async Task OnGetAsync()
        {
            SchoolLockerOverviewDtos = await _unitOfWork.LockerRepository.GetLockersOverviewAsync();

            // TODO: eigene Buchungen laden
            // var pupil = await _userManager.GetUserAsync(HttpContext.User);
            // ...
        }
    }
}
