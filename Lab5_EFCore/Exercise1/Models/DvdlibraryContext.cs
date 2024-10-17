using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercise1.Models;

public partial class DvdlibraryContext : DbContext
{
    public DvdlibraryContext()
    {
    }

    public DvdlibraryContext(DbContextOptions<DvdlibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dvd> Dvds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost; database=DVDLibrary; uid=root; password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dvd>(entity =>
        {
            entity.HasKey(e => e.DvdcodeNo).HasName("PRIMARY");

            entity.ToTable("dvds");

            entity.Property(e => e.DvdcodeNo).HasColumnName("DVDCodeNo");
            entity.Property(e => e.Dvdtitle)
                .HasMaxLength(100)
                .HasColumnName("DVDTitle");
            entity.Property(e => e.Language).HasMaxLength(20);
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.SubTitle).HasColumnType("bit");
        });

        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
