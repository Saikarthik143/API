using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiDemo.Models
{
    public partial class PracticeDBContext : DbContext
    {
        public PracticeDBContext()
        {
        }

        public PracticeDBContext(DbContextOptions<PracticeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Department1> Department1 { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employee2> Employee2 { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product156> Product156 { get; set; }
        public virtual DbSet<Product16> Product16 { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Project2> Project2 { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PracticeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContactName)
                    .HasColumnName("contactName")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .HasColumnName("dept_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptNo)
                    .HasColumnName("dept_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PK__employee__D9509F6DE1FAFF8E");

                entity.ToTable("employee");

                entity.Property(e => e.Eid).HasColumnName("eid");

                entity.Property(e => e.Designation)
                    .HasColumnName("designation")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Joindate)
                    .HasColumnName("joindate")
                    .HasColumnType("date");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__employee__pid__15502E78");
            });

            modelBuilder.Entity<Employee2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptNo)
                    .HasColumnName("dept_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFname)
                    .HasColumnName("emp_fname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLname)
                    .HasColumnName("emp_lname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("customerId")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Shipaddres)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Shipname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Shippeddate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product156>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Product16>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__project__DD37D91A6DFCCE3D");

                entity.ToTable("project");

                entity.HasIndex(e => e.Pname)
                    .HasName("UQ__project__1FC9734C7376B50F")
                    .IsUnique();

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Edate)
                    .HasColumnName("edate")
                    .HasColumnType("date");

                entity.Property(e => e.Pname)
                    .IsRequired()
                    .HasColumnName("pname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sdate)
                    .HasColumnName("sdate")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Project2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProjectName)
                    .HasColumnName("project_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .HasColumnName("project_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.Enterdate)
                    .HasColumnName("enterdate")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .HasColumnName("project_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
