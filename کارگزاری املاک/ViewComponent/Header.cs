using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.ViewComponent
{
    public class Header :Microsoft.AspNetCore.Mvc.ViewComponent
    {

        private readonly ApplicationDbContext _context;

        public Header(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await _context.users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                HeaderViewModel model = new()
                {
                    FullName = user.FullName
                };

                return View("/Pages/Shared/ViewComponent/_HeaderViewComponent.cshtml", model );




            }


            return View("/Pages/Shared/ViewComponent/_HeaderViewComponent.cshtml" , new HeaderViewModel());
        }
    }
}
