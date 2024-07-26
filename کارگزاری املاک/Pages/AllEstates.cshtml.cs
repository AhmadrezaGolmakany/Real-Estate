using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using کارگزاری_املاک.Data;
using کارگزاری_املاک.Models;

namespace کارگزاری_املاک.Pages
{
    public class AllEstatesModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public AllEstatesModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<EstateModel> Model { set; get; }

        public void OnGet()
        {
            Model = _context.estates.ToList();
            

        }
    }
}
