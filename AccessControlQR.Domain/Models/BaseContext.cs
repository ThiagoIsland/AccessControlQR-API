// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
//
// namespace AcessControlQR.Infrastructure.Models;
//
// public partial class BaseContext : DbContext
// {
//     public BaseContext()
//     {
//     }
//
//     public BaseContext(DbContextOptions<BaseContext> options)
//         : base(options)
//     {
//     }
//
//     public virtual DbSet<AccessRecord> AccessRecords { get; set; }
//
//     public virtual DbSet<User> Users { get; set; }
//
//     public virtual DbSet<Visitor> Visitors { get; set; }
//
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseNpgsql("Host=localhost;Database=accesscontrol;Username=postgres;Password=12345");
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<AccessRecord>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("AccessRecords_pkey");
//
//             entity.Property(e => e.AccessTime)
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .HasColumnType("timestamp without time zone");
//             entity.Property(e => e.AccessType).HasMaxLength(20);
//             entity.Property(e => e.Status).HasMaxLength(20);
//
//             entity.HasOne(d => d.User).WithMany(p => p.AccessRecords)
//                 .HasForeignKey(d => d.UserId)
//                 .OnDelete(DeleteBehavior.Cascade)
//                 .HasConstraintName("AccessRecords_UserId_fkey");
//
//             entity.HasOne(d => d.Visitor).WithMany(p => p.AccessRecords)
//                 .HasForeignKey(d => d.VisitorId)
//                 .OnDelete(DeleteBehavior.Cascade)
//                 .HasConstraintName("AccessRecords_VisitorId_fkey");
//         });
//
//         modelBuilder.Entity<User>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("Users_pkey");
//
//             entity.HasIndex(e => e.Email, "Users_Email_key").IsUnique();
//
//             entity.HasIndex(e => e.Username, "Users_Username_key").IsUnique();
//
//             entity.Property(e => e.CreatedAt)
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .HasColumnType("timestamp without time zone");
//             entity.Property(e => e.Email).HasMaxLength(100);
//             entity.Property(e => e.Role).HasMaxLength(20);
//             entity.Property(e => e.UpdatedAt)
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .HasColumnType("timestamp without time zone");
//             entity.Property(e => e.Username).HasMaxLength(50);
//         });
//
//         modelBuilder.Entity<Visitor>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("Visitors_pkey");
//
//             entity.HasIndex(e => e.Email, "Visitors_Email_key").IsUnique();
//
//             entity.HasIndex(e => e.Qrcode, "Visitors_QRCode_key").IsUnique();
//
//             entity.Property(e => e.CreatedAt)
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .HasColumnType("timestamp without time zone");
//             entity.Property(e => e.Email).HasMaxLength(100);
//             entity.Property(e => e.Name).HasMaxLength(100);
//             entity.Property(e => e.Phone).HasMaxLength(20);
//             entity.Property(e => e.Qrcode).HasColumnName("QRCode");
//             entity.Property(e => e.Status)
//                 .HasMaxLength(20)
//                 .HasDefaultValueSql("'Pending'::character varying");
//             entity.Property(e => e.UpdatedAt)
//                 .HasDefaultValueSql("CURRENT_TIMESTAMP")
//                 .HasColumnType("timestamp without time zone");
//         });
//
//         OnModelCreatingPartial(modelBuilder);
//     }
//
//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
