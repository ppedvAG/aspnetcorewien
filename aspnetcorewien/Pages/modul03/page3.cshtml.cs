using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.modul03
{
    public class page3Model : PageModel
    {
        public int _Id { get; set; }
        public void OnGet([FromQuery] int id)
        {
            _Id = id;
        }
    }
}