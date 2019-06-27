using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcorewien.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul06
{
    public class Northwind1Model : PageModel
    {
        public List<Customers> KundenListe { get; set; }
      
        public void OnGet([FromServices] northwindContext ef)
        {

           // var ef = new northwindContext();
            KundenListe = ef.Customers.ToList();
        }
    }
}