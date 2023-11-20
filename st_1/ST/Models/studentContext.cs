using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ST.Models;

#nullable disable

namespace ST.Models
{
    public partial class studentContext : DbContext
    {
        public studentContext()
        {
        }

        public studentContext(DbContextOptions<studentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodeCompany> CodeCompanies { get; set; }
        public virtual DbSet<CodeNationality> CodeNationalities { get; set; }
        public virtual DbSet<CodeUniversty> CodeUniversties { get; set; }
       // public virtual DbSet<CodeUniversty> CollegeName { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentMaster> StudentMasters { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=DESKTOP-3DMSSQF;Initial Catalog=studentTraining;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CodeCompany>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CodeNationality>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CodeUniversty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CompanyTypeNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CompanyType)
                    .HasConstraintName("FK_company_code_company");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SmId)
                    .HasConstraintName("FK_courses_studentMaster");
            });

            modelBuilder.Entity<StudentMaster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.StudentMasters)
                    .HasForeignKey(d => d.Nationality)
                    .HasConstraintName("FK_studentMaster_code_nationality");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SmId)
                    .HasConstraintName("FK_Transaction_studentMaster");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.UniversityTypeNavigation)
                    .WithMany(p => p.Universities)
                    .HasForeignKey(d => d.UniversityType)
                    .HasConstraintName("FK_University_code_universty");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Phon).IsFixedLength(true);

                entity.HasOne(d => d.Sm)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SmId)
                    .HasConstraintName("FK_user_studentMaster");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK_user_userType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<ST.Models.CollegeName> CollegeName { get; set; }

        public DbSet<ST.Models.GenderType> GenderType { get; set; }

        public DbSet<ST.Models.Majer> Majer { get; set; }
    }
}
