using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorewien.Pages.Modul06
{
    public class Aufgaben
    {
        [Key]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Termin { get; set; }
        public bool Fertig { get; set; }

    }
    public class AufgabenContext:DbContext
    {
        public AufgabenContext()
        {

        }
        public AufgabenContext(DbContextOptions<AufgabenContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Aufgaben> Aufgaben { get; set; }
    }
}
