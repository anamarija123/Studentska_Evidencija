using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studentska_Evidencija_PIN.Models;

namespace Studentska_Evidencija_PIN.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Studentska_Evidencija_PIN.Models.Smjer> Smjer { get; set; }

        public DbSet<Studentska_Evidencija_PIN.Models.Student> Student { get; set; }

        public DbSet<Studentska_Evidencija_PIN.Models.Nastavnik> Nastavnik { get; set; }

        public DbSet<Studentska_Evidencija_PIN.Models.Predmet> Predmet { get; set; }

        public DbSet<Studentska_Evidencija_PIN.Models.Ispit> Ispit { get; set; }
    }
}
