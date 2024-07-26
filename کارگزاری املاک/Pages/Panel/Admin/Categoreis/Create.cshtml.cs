using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.Pages.Panel.Admin.Categoreis
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CategoryModel Model { get; set; }

        public async Task<IActionResult> OnGet()
        {
            return Page() ;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.categories.AddAsync(Model);
            await _context.SaveChangesAsync();
            return RedirectToPage("/panel/admin/Categoreis/index");
        }
    }
}
