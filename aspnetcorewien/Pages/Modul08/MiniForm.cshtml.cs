using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul08
{
    public class MiniFormModel : PageModel
    {
        [BindProperty]
        public Person MyPerson { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

            }

        }
    }
}