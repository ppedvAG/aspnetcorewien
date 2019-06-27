using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    public class CookieTestModel : PageModel
    {
        public void OnGet()
        {

            
            var options = new CookieOptions {
                Domain = ".ppedv.de",
                Expires = DateTime.Now.AddDays(30)
                
            };
            Response.Cookies.Append("Hannes", "Wert",options);

            var o = Request.Cookies["hannes"];

        }
    }
}