using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcorewien.Pages.modul02
{
    public class DISampleModel : PageModel
    {
        
        public requestCountcs _allrequest { get; set; }
        public DISampleModel(requestCountcs allrequests)
        {
            _allrequest = allrequests;
        }
        public void OnGet([FromServices] requestCountcs allrequests1)
        {
            _allrequest.Anzahl++;
            allrequests1.Anzahl++;
        }
    }
}