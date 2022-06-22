using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PcyhoHospital.Models
{
    public partial class WorkbazeContext : DbContext
    {
        public WorkbazeContext()
        {
        }

        public WorkbazeContext(DbContextOptions<WorkbazeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Cabinet> Cabinets { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Function> Functions { get; set; } = null!;
        public virtual DbSet<Quantity> Quantities { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Sick> Sicks { get; set; } = null!;
        public virtual DbSet<SickDiagnosis> SickDiagnoses { get; set; } = null!;
        public virtual DbSet<Specialization> Specializations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Workbaze;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.ToTable("Cabinet");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Cabinet)
                    .HasForeignKey<Cabinet>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cabinet_Doctor");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("Diagnosis");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Branch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Branch");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_Doctor_Function");

                entity.HasOne(d => d.ScheduleNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Schedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Schedule");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Specialization");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("Function");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Quantity>(entity =>
            {
                entity.ToTable("Quantity");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Category");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.DiagnosisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Diagnosis1");
            });

            modelBuilder.Entity<Sick>(entity =>
            {
                entity.ToTable("Sick");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PersonalInformation).HasMaxLength(150);

                entity.HasOne(d => d.BranchNavigation)
                    .WithMany(p => p.Sicks)
                    .HasForeignKey(d => d.Branch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sick_Branch");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Sicks)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sick_Doctor");
            });

            modelBuilder.Entity<SickDiagnosis>(entity =>
            {
                entity.ToTable("SickDiagnosis");

                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.SickDiagnoses)
                    .HasForeignKey(d => d.DiagnosisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SickDiagnosis_Diagnosis");

                entity.HasOne(d => d.DiagnosisNavigation)
                    .WithMany(p => p.SickDiagnoses)
                    .HasForeignKey(d => d.DiagnosisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SickDiagnosis_Sick");
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.ToTable("Specialization");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
