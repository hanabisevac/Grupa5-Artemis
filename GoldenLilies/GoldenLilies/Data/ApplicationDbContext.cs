using GoldenLilies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenLilies.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Atrakcija> Atrakcija { get; set; }
        public DbSet<AtrakcijeTure> AtrakcijeTure { get; set; }
        public DbSet<Fotografija> Fotografija { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Posjete> Posjete { get; set; }
        public DbSet<Prijavljeni> Prijavljeni { get; set; }
        public DbSet<Tura> Tura { get; set; }
        public DbSet<VrstaAtrakcije> VrstaAtrakcije { get; set; }
        public DbSet<VrstaKorisnika> VrstaKorisnika { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Atrakcija>().ToTable("Atrakcija");
            builder.Entity<AtrakcijeTure>().ToTable("AtrakcijeTure");
            builder.Entity<Fotografija>().ToTable("Fotografija");
            builder.Entity<Korisnik>().ToTable("Korisnik");
            builder.Entity<Lokacija>().ToTable("Lokacija");
            builder.Entity<Posjete>().ToTable("Posjete");
            builder.Entity<Prijavljeni>().ToTable("Prijavljeni");
            builder.Entity<Tura>().ToTable("Tura");
            builder.Entity<VrstaAtrakcije>().ToTable("VrstaAtrakcije");
            builder.Entity<VrstaKorisnika>().ToTable("VrstaKorisnika");
            base.OnModelCreating(builder);

        }
    }
}
