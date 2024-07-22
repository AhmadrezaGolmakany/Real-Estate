using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages.Admin.Categoreis
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CategoryModel> Category { get; set; }

        public void OnGet()
        {
            Category = _context.categories.ToList();
        }
    }
}
