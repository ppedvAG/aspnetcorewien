using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorewien.Pages.Modul08
{
    public class Person
    {
        [Display(Name="Hey wie ald?")]
        [Range(18,99,ErrorMessage ="du darfst hier nicht rein")]
        public int Alter { get; set; }
        [Required(ErrorMessage ="mach da was rein!")]
        public String Name { get; set; }
    }
}
