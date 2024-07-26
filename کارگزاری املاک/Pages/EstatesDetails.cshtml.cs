using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.Pages
{
    public class EstatesDetails : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EstatesDetails(ApplicationDbContext context)
        {
            _context = context;
        }

        public EstatesDetailViewModel EstatesVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var Estates = await _context.estates
                 .Include(c => c.CategoryModel)
                 .FirstOrDefaultAsync(e => e.Id == id);

            if (Estates is null)
            {
                return NotFound();
            }

            EstatesVM = new()
            {
                Estate = Estates,
                suggestedproducts = _context.estates.Include(c => c.CategoryModel)
                    .Where(e =>  e.Id != Estates.Id)
                    .Take(4)
                    .ToList()
            };

            return Page();

        }

        public async Task<IActionResult> OnPostAddToFavorites(int id )
        {
            if (User is null || !User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login?returnUrl=/EstatesDetails?Id=" + id);
            }



            if (id <= 0)
            {
                return NotFound();
            }

            var estates = await _context.estates.FirstOrDefaultAsync(e => e.Id == id);
            if (estates is null)
            {
                return NotFound();
            }

            var user = await _context.users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            var checkIfredundant = await _context.favorites.FirstOrDefaultAsync(f => f.userId == user.Id && f.EstateId == id);

            if (checkIfredundant is null)
            {
                await _context.AddAsync(new FavoriteModel()
                {
                    EstateId = id,
                    userId = user.Id
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("EstatesDetails", new { id });
        }
    }
}
