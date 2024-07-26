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
    public class DeleteModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public DeleteModel(کارگزاری_املاک.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EstatesViewModel EstateModel { get; set; }


        private void InitCategories()
        {
            EstateModel = new()
            {
                CategoryOptions = new SelectList(_context.categories, nameof(CategoryModel.Id), nameof(CategoryModel.Title))
            };
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate = await _context.estates.FindAsync(id);
            if (estate is null)
            {
                return NotFound();
            }
            InitCategories();

            EstateModel.Estate = estate;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estate  = await _context.estates.FindAsync(id);

            if (estate is not null)
            {
                _context.estates.Remove(estate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
       }
    }
}
