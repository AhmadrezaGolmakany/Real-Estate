using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages.Admin.Categoreis
{
    public class DeleteModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public DeleteModel(کارگزاری_املاک.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryModel CategoryModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryModel = await _context.categories.FirstOrDefaultAsync(m => m.Id == id);

            if (CategoryModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryModel = await _context.categories.FindAsync(id);

            if (CategoryModel != null)
            {
                _context.categories.Remove(CategoryModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
