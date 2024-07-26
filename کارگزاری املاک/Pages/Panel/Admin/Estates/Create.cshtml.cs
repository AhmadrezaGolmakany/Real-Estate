using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;
using کارگزاری_املاک.Models.ViewModels;

namespace کارگزاری_املاک.Pages.Panel.Admin.Estates
{
    public class CreateModel(ApplicationDbContext db) : PageModel
    {
        [BindProperty]
        public EstatesViewModel? ViewModel { get; set; }
        public void OnGet()
        {
            InitCategories();
        }
        private void InitCategories()
        {
            ViewModel = new()
            {
                CategoryOptions = new SelectList(db.categories, nameof(CategoryModel.Id), nameof(CategoryModel.Title))
            };
        }
        public async Task<IActionResult> OnPost()
        {
            #region Validation
            if (!ModelState.IsValid || string.IsNullOrEmpty(ViewModel.SelectedCategory))
            {
                InitCategories();
                return Page();
            }
            bool check = int.TryParse(ViewModel.SelectedCategory, out int categoryId);
            if (check is false)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");
                InitCategories();
                return Page();
            }
            var category = await db.categories.FindAsync(categoryId);
            if (category is null)
            {
                ModelState.AddModelError(string.Empty, "دسته بندی انتخاب شده نامعتبر است");
                InitCategories();
                return Page();
            }
            #endregion
            #region Upload Image

            if (ViewModel.ImgUp is not null)
            {
                string saveDir = "wwwroot/image/Estates";
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);

                ViewModel.Estate.Image = Guid.NewGuid().ToString() + Path.GetExtension(ViewModel.ImgUp.FileName);
                string savepath = Path.Combine(Directory.GetCurrentDirectory(), saveDir, ViewModel.Estate.Image);
                using var filestream = new FileStream(savepath, FileMode.Create);
                ViewModel.ImgUp.CopyTo(filestream);
            }
            #endregion
            ViewModel.Estate.categoryId = categoryId;
            await db.estates.AddAsync(ViewModel.Estate);
            await db.SaveChangesAsync();
            return RedirectToPage("/Panel/Admin/Estates/Index");
        }
    }

}
