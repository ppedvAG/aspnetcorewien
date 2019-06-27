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
    public class IndexModel : PageModel
    {
        private readonly aspnetcorewien.Models.northwindContext _context;

        public IndexModel(aspnetcorewien.Models.northwindContext context)
        {
            _context = context;
        }

        public IList<Customers> Customers { get;set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }
    }
}
