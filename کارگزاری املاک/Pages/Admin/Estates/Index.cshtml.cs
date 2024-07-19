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
    public class IndexModel : PageModel
    {
        private readonly کارگزاری_املاک.Data.ApplicationDbContext _context;

        public IndexModel(کارگزاری_املاک.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EstateModel> EstateModel { get;set; }

        public async Task OnGetAsync()
        {
            EstateModel = await _context.estates.ToListAsync();
        }
    }
}
