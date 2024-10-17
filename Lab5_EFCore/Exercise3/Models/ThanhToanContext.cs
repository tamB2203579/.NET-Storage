using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercise3.Models;

public partial class ThanhToanContext : DbContext
{
    public ThanhToanContext()
    {
    }

    public ThanhToanContext(DbContextOptions<ThanhToanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost; database=ThanhToan; uid=root; password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.SoHd).HasName("PRIMARY");

            entity.ToTable("khachhang");

            entity.HasIndex(e => e.Phong, "Phong");

            entity.Property(e => e.SoHd).HasColumnName("SoHD");
            entity.Property(e => e.NgayTt)
                .HasColumnType("datetime")
                .HasColumnName("NgayTT");
            entity.Property(e => e.SoCmnd)
                .HasMaxLength(12)
                .HasColumnName("SoCMND");
            entity.Property(e => e.SoTien).HasPrecision(10);
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");

            entity.HasOne(d => d.PhongNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.Phong)
                .HasConstraintName("khachhang_ibfk_1");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PRIMARY");

            entity.ToTable("phong");

            entity.Property(e => e.TenPhong).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
