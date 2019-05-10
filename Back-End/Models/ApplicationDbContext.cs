using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backEnd.Models
{
    public partial class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HairColor> HairColor { get; set; }
        public virtual DbSet<HairCut> HairCut { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<updo> updo { get; set; }

        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<HairColor>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.name).HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<HairCut>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.name).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.password).HasColumnType("varchar(50)");

                entity.Property(e => e.userName).HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<updo>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.name).HasColumnType("VARCHAR(50)");
            });
        }
    }
}
