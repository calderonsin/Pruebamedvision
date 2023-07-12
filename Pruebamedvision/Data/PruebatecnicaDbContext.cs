using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pruebamedvision.Models;

namespace Pruebamedvision.Data
{
    public class PruebatecnicaDbContext: IdentityDbContext<IdentityUser>    
    {
        private readonly IConfiguration Configuration;
        public PruebatecnicaDbContext(DbContextOptions options ,IConfiguration configuration) : base(options) {
            Configuration = configuration;
        
        }
        
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Persona> Personas { get; set; }

        public DbSet<MotivoCita> MotivoCitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Citas)
                .WithOne(e => e.Persona)
            .HasForeignKey(e => e.PersonaId)
        .IsRequired();


            modelBuilder.Entity<Cita>()
                .HasMany(e => e.MotivoCitas)
                .WithMany(e => e.Citas);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }



    
    }

