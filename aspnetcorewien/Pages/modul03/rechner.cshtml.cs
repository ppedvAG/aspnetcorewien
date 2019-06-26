using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.modul03
{
    public class rechnerModel : PageModel
    {
        public int Ergebnis { get; set; }
        [BindProperty]
        public Hannes MyHannes { get; set; }

        public void OnGet()
        {

        }
        public void OnPost()
        {
        Ergebnis= int.Parse(   Request.Form["text1"]) +int.Parse( Request.Form["text2"]);
        }
        public void OnPostSub([FromForm] string text1,[FromForm]string text2)
        {
            Ergebnis = int.Parse(text1) - int.Parse(text2);
        }
        public void OnPostMulitply()
        {
            Ergebnis =MyHannes.text1*MyHannes.text2;
        }

    }
    public class Hannes
    {
        public int text1 { get; set; }
        public int text2 { get; set; }
    }
}