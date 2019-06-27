using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    public class seite1Model : PageModel
    {
        public void OnGet()
        {

        }
        public void OnPost([FromForm] string eins)
        {
            TempData.Add("Hannes", eins);
            Response.Redirect("seite2");
        }
    }
}