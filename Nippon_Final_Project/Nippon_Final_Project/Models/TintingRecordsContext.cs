using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nippon_Final_Project.Models;

public partial class TintingRecordsContext : DbContext
{
    public TintingRecordsContext()
    {
    }

    public TintingRecordsContext(DbContextOptions<TintingRecordsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colourant> Colourants { get; set; }

    public virtual DbSet<MasterPage> MasterPages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=Tinting_Records; Username=postgres; Password=rak47675");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colourant>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("Colourants_pkey");

            entity.Property(e => e.RequestId).HasColumnName("Request_Id");
            entity.Property(e => e.BatchNo).HasColumnName("Batch_No");
            entity.Property(e => e.DispensingMachine).HasColumnName("Dispensing_Machine");
            entity.Property(e => e.EntryDate)
                .HasColumnType("time with time zone")
                .HasColumnName("Entry_Date");
            entity.Property(e => e.Mfg).HasColumnName("MFG");
        });

        modelBuilder.Entity<MasterPage>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Master_page_pkey");

            entity.ToTable("Master_page");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_ID");
            entity.Property(e => e.UserName).HasColumnName("User_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
