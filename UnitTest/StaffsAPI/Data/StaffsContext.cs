using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StaffsAPI.Data;

public partial class StaffsContext : DbContext
{
    public StaffsContext()
    {
    }

    public StaffsContext(DbContextOptions<StaffsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=staffs;uid=root;Password=123456;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepId).HasColumnName("depID");
            entity.Property(e => e.DepName)
                .HasMaxLength(100)
                .HasColumnName("depName");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartmentId, "departmentID");

            entity.HasIndex(e => e.GenderId, "genderID");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.DateofBirth)
                .HasColumnType("date")
                .HasColumnName("dateofBirth");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.GenderId).HasColumnName("genderID");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("employee_ibfk_2");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenId).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(e => e.GenId).HasColumnName("genID");
            entity.Property(e => e.GenName)
                .HasMaxLength(6)
                .HasColumnName("genName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
