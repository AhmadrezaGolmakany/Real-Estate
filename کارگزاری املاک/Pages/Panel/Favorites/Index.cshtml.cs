using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages.Panel.Favorites
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FavoriteModel> Favorite { get; set; }


        public async Task<IActionResult> OnGet()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/Panel/Favorites");
            }


            var user = await _context.users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);


            Favorite = await _context.favorites
                .Include(e => e.Estate)
                .Where(f => f.userId == user.Id).ToListAsync();

            return Page();


        }
    }
}
