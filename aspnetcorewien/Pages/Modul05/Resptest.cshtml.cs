using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    public class ResptestModel : PageModel
    {
        public void OnGet()
        {

        }
        public void OnGetUmleitung()
        {
            HttpContext.Response.Redirect("~/Modul04/sessiontest");
        }
    }
}