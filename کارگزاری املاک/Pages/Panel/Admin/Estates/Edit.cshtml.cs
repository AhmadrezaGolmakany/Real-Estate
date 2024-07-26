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
    public class EditModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public EditModel(کارگزاری_املاک.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            #region Validation
            if (!ModelState.IsValid || string.IsNullOrEmpty(EstateModel.SelectedCategory))
            {
                InitCategories();
                return Page();
            }
            bool check = int.TryParse(EstateModel.SelectedCategory, out int categoryId);
            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");
                InitCategories();
                return Page();
            }
            var category = await _context.categories.FindAsync(categoryId);
            if (category is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");
                InitCategories();
                return Page();
            }
            #endregion
            #region Upload Image
            if (EstateModel.ImgUp is not null)
            {
                string saveDir = "wwwroot/image/Estates";

                if (EstateModel.Estate.Image is not null)
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, EstateModel.Estate.Image);
                    if (System.IO.File.Exists(deletePath))
                        System.IO.File.Delete(deletePath);
                }

                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                EstateModel.Estate.Image = Guid.NewGuid().ToString() + Path.GetExtension(EstateModel.ImgUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, EstateModel.Estate.Image);
                using var filestream = new FileStream(savepath, FileMode.Create);
                EstateModel.ImgUp.CopyTo(filestream);
            }
            #endregion
            EstateModel.Estate.categoryId = categoryId;
             _context.estates.Update(EstateModel.Estate);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Panel/Admin/Estates/Index");
            return Page();
        }

        private bool EstateModelExists(int id)
        {
            return false;
        }
    }
}
