using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcorewien.Pages.Modul06;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace aspnetcorewien.Pages.Modul08
{
    public class AufgabenPageMitAjaxModel : PageModel
    {
        AufgabenContext _context;
        public List<Aufgaben> ListeAufgaben { get; set; }
        [BindProperty]
        public Aufgaben NeuAufgabe { get; set; }
        public AufgabenPageMitAjaxModel(AufgabenContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            ListeAufgaben = _context.Aufgaben.ToList();
            NeuAufgabe = new Aufgaben() { Termin = DateTime.Now.AddHours(2) };

        }
        public IActionResult OnPost()

        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            NeuAufgabe.Fertig = false;
            _context.Add(NeuAufgabe);
            _context.SaveChanges();
            ListeAufgaben = _context.Aufgaben.ToList();
            return Page();
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
