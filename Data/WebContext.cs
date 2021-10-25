using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFormacion.Models;

namespace WebFormacion.Data
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        public DbSet<Entidad> EntidadFormacion { get; set; }

        public DbSet<Contacto> Contacto { get; set; }

        public DbSet<EntidadContacto> EntidadContacto { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<CursoEntidad> CursoEntidad { get; set; }

        public DbSet<Alumno> Alumno { get; set; }

        public DbSet<Historial> Historial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidad>().ToTable("Entidad");
            modelBuilder.Entity<Contacto>().ToTable("Contacto");
            modelBuilder.Entity<EntidadContacto>().ToTable("EntidadContacto");
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<CursoEntidad>().ToTable("CursoEntidad");
            modelBuilder.Entity<Alumno>().ToTable("Alumno");
            modelBuilder.Entity<Historial>().ToTable("HistorialContactos");

            modelBuilder.Entity<EntidadContacto>()
                .HasKey(c => new { c.EntidadID, c.ContactoID });

            modelBuilder.Entity<CursoEntidad>()
                .HasKey(c => new { c.EntidadID, c.CursoID });
        }
    }
}
