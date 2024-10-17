using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercise2.Models;

public partial class QlcbContext : DbContext
{
    public QlcbContext()
    {
    }

    public QlcbContext(DbContextOptions<QlcbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canbo> Canbos { get; set; }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost; database=QLCB; uid=root; password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canbo>(entity =>
        {
            entity.HasKey(e => e.MaCb).HasName("PRIMARY");

            entity.ToTable("canbo");

            entity.HasIndex(e => e.ChucVuCb, "ChucVuCB");

            entity.Property(e => e.MaCb).HasColumnName("MaCB");
            entity.Property(e => e.ChucVuCb).HasColumnName("ChucVuCB");
            entity.Property(e => e.DonGia).HasPrecision(10);
            entity.Property(e => e.TenCb)
                .HasMaxLength(255)
                .HasColumnName("TenCB");

            entity.HasOne(d => d.ChucVuCbNavigation).WithMany(p => p.Canbos)
                .HasForeignKey(d => d.ChucVuCb)
                .HasConstraintName("canbo_ibfk_1");
        });

        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PRIMARY");

            entity.ToTable("chucvu");

            entity.Property(e => e.MaCv).HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(255)
                .HasColumnName("TenCV");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
