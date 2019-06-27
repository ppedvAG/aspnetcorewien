using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    public class ImageListeModel : PageModel
    {
        public string[] dateien { get; set; }
        public void OnGet()
        {
            var pfad = AppDomain.CurrentDomain.GetData("wwwroot").ToString();
            dateien = Directory.GetFiles(pfad);

        }
        public string ClearPath(string datei)
        {
            return datei.Replace(AppDomain.CurrentDomain.GetData("wwwroot").ToString(), "");
        }
    }
}