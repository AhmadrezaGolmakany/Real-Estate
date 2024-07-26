using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages.Panel.Admin.Categoreis
{
    public class DetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
