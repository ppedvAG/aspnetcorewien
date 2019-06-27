using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcorewien.Models;

namespace aspnetcorewien.Pages.Modul06
{
    public class DetailsModel : PageModel
    {
        private readonly aspnetcorewien.Models.northwindContext _context;

        public DetailsModel(aspnetcorewien.Models.northwindContext context)
        {
            _context = context;
        }

        public Customers Customers { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customers = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
