using System;
using Microsoft.EntityFrameworkCore;
using Entity;


namespace DAL
{
    public class AsignaturaContext : DbContext
    {
        public AsignaturaContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Docente> Docentes { get; set; }
        public DbSet<PlanAsignatura> PlanAsignaturas{get; set;}
        public DbSet<Asignatura> Asignaturas{get; set;}
    }
}
