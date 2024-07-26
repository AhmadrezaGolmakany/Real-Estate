using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.Pages.Panel.Admin.Estates
{
    public class DetailsModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public DetailsModel(کارگزاری_املاک.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public EstateModel EstateModel { get; set; }

      

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            EstateModel = await _context.estates
                .Include(c => c.CategoryModel)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (EstateModel is null)
            {
                return NotFound();
            }


            return Page();
        }
    }
}
