using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.Modul05
{
    public class BildUploadModel : PageModel
    {
        public void OnGet()
        {

        }
        public void OnPost(IFormFile datei)
        {
            var name = Path.GetFileName(datei.FileName);
            // var pfad = @"C:\aspnetcore\aspnetcorewien\aspnetcorewien\images\"+name; //Todo: peitsche dich selbst

            var pfad = AppDomain.CurrentDomain.GetData("wwwroot").ToString() + name;
            using (var fs = new FileStream(pfad, FileMode.Create))
            {
                datei.CopyTo(fs);
            }


    }
}
}