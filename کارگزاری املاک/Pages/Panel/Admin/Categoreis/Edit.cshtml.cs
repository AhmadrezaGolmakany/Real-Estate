using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.Pages.Panel.Admin.Categoreis
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryModel ViewModel { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ViewModel = await _context.categories.FirstOrDefaultAsync(c=>c.Id==id);

            if (ViewModel == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id <= 0)
            {
                return NotFound();
            }

            _context.categories.Update(ViewModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Categoreis/index");
        }
    }
}
