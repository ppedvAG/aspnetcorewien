using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcorewien.Pages.Modul06;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul07
{
    public class AufgabenPageMitAjaxModel : PageModel
    {
        AufgabenContext _context;
        public List<Aufgaben> ListeAufgaben { get; set; }
        public AufgabenContext NeuAufgabe { get; set; }
        public AufgabenPageMitAjaxModel(AufgabenContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            ListeAufgaben = _context.Aufgaben.ToList();

        }
        public PartialViewResult OnGetErledigt(int ID)
        {
            if (ID != 0)

            {
                var item = _context.Aufgaben.Find(ID);
                item.Fertig = !item.Fertig;
                _context.Update(item);
                _context.SaveChanges();

            }
            ListeAufgaben = _context.Aufgaben.ToList();
            return Partial("_AufgabenListePartial", this);
        }
    }
}
