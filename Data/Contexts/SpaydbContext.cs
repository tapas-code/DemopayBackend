using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using spayserver.Data.Models;

namespace spayserver.Data.Contexts;

public partial class SpaydbContext : DbContext
{
    public SpaydbContext()
    {
    }

    public SpaydbContext(DbContextOptions<SpaydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<User> Users { get; set; }
<<<<<<< HEAD


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=desktop-ab199u8;Initial Catalog=spaydb;User ID=Tapash;Password=Db123;Encrypt=True;Trust Server Certificate=True");

||||||| 07773a0

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=desktop-ab199u8;Initial Catalog=spaydb;User ID=Tapash;Password=Db123;Encrypt=True;Trust Server Certificate=True");

=======
>>>>>>> e5dd9980aea34e52aec0ff1f3a89e9e208fbdf04
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF36A46FA708C");

            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasMany(d => d.Users).WithMany(p => p.Groups)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupUser",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GroupUsers_UserId"),
                    l => l.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GroupUsers_GroupId"),
                    j =>
                    {
                        j.HasKey("GroupId", "UserId");
                        j.ToTable("GroupUsers");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CE1E0123B");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E45B8FADAF").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534D1A64C14").IsUnique();

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.imgUrl)
                .HasMaxLength(300)
                .IsUnicode(false);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
