using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.modul03
{
    public class PgHandlerModel : PageModel
    {
        public string Einstieg { get; set; }
        public void OnGet()
        {
            Einstieg = "OnGet";
        }
        public void OnGetDemo()
        {
            Einstieg = "Page Handler";
        }
    }
}