using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages.Admin.Estates
{
    public class DetailsModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public DetailsModel(کارگزاری_املاک.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public EstateModel EstateModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EstateModel = await _context.estates.FirstOrDefaultAsync(m => m.Id == id);

            if (EstateModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
