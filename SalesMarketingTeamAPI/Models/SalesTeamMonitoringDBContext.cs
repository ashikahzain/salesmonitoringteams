using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesMarketingTeamAPI.Models
{
    public partial class SalesTeamMonitoringDBContext : DbContext
    {
        public SalesTeamMonitoringDBContext()
        {
        }

        public SalesTeamMonitoringDBContext(DbContextOptions<SalesTeamMonitoringDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employeeregistration> Employeeregistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Visittable> Visittable { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ASHIKAHUSSAIN\\SQLEXPRESS; Initial Catalog=SalesTeamMonitoringDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employeeregistration>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__EMPLOYEE__1299A86137E56BE3");

                entity.ToTable("EMPLOYEEREGISTRATION");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Employeeregistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__EMPLOYEERE__l_id__38996AB5");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LOGIN__A7C7B6F86D0DC47C");

                entity.ToTable("LOGIN");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visittable>(entity =>
            {
                entity.HasKey(e => e.VisitId)
                    .HasName("PK__VISITTAB__375A75E14D5A3523");

                entity.ToTable("VISITTABLE");

                entity.Property(e => e.VisitId).HasColumnName("visit_id");

                entity.Property(e => e.ContactNo)
                    .HasColumnName("contact_no")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contact_person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("cust_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("interest_product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("visit_subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Visittable)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__VISITTABL__emp_i__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
