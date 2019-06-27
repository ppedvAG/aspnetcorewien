using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
   
   [ ResponseCache(VaryByHeader = "User-Agent",Duration = 30)]
    public class chachedModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}