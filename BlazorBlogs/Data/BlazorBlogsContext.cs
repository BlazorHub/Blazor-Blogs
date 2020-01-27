﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using BlazorBlogs.Data.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorBlogs.Data
{
    public partial class BlazorBlogsContext : DbContext
    {
        public BlazorBlogsContext()
        {
        }

        public BlazorBlogsContext(DbContextOptions<BlazorBlogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BlogCategory> BlogCategory { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DisplayName).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogCategory)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_BlogCategory_Blogs");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BlogCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BlogCategory_Categorys");
            });

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.Property(e => e.BlogContent).IsRequired();

                entity.Property(e => e.BlogDate).HasColumnType("datetime");

                entity.Property(e => e.BlogSummary).IsRequired();

                entity.Property(e => e.BlogTitle)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.BlogUserName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("Comment")
                    .HasMaxLength(4000);

                entity.Property(e => e.CommentCreated).HasColumnType("datetime");

                entity.Property(e => e.CommentIpaddress)
                    .IsRequired()
                    .HasColumnName("CommentIPAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.CommentUpdated).HasColumnType("datetime");

                entity.Property(e => e.CommentUserId)
                    .IsRequired()
                    .HasColumnName("CommentUserID")
                    .HasMaxLength(500);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("FK_Comment_Blogs");

                entity.HasOne(d => d.ParentComment)
                    .WithMany(p => p.InverseParentComment)
                    .HasForeignKey(d => d.ParentCommentId)
                    .HasConstraintName("FK_Comment_Comment");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogAction)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogIpaddress)
                    .IsRequired()
                    .HasColumnName("LogIPAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.LogUserName).HasMaxLength(500);
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingId)
                    .HasName("PK_ADefHelpDesk_Settings");

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.SettingName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}