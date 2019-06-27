using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    [ResponseCache(Duration = 10, VaryByQueryKeys =new string[]{"*"})]
    public class chachedModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}