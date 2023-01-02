using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatalogTop.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NumAtr> NumAtrs { get; set; } = null!;
        public virtual DbSet<PType> PTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreItem> StoreItems { get; set; } = null!;
        public virtual DbSet<StrAtr> StrAtrs { get; set; } = null!;
        public virtual DbSet<Sub> Subs { get; set; } = null!;
        public virtual DbSet<SubUser> SubUsers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumAtr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("num_atr");

                entity.Property(e => e.AtrKey)
                    .HasColumnType("character varying")
                    .HasColumnName("atr_key");

                entity.Property(e => e.AtrValue).HasColumnName("atr_value");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("num_atr_p_id_fkey");
            });

            modelBuilder.Entity<PType>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("p_type_pkey");

                entity.ToTable("p_type");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.IconUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("icon_url");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Model, "uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Model)
                    .HasColumnType("character varying")
                    .HasColumnName("model");

                entity.Property(e => e.PType)
                    .HasColumnType("character varying")
                    .HasColumnName("p_type");

                entity.Property(e => e.PhotoUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("photo_url");

                entity.HasOne(d => d.PTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_p_type_fkey");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Title)
                    .HasName("status_pkey");

                entity.ToTable("status");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasIndex(e => e.Title, "store_title_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.Url)
                    .HasColumnType("character varying")
                    .HasColumnName("url");
            });

            modelBuilder.Entity<StoreItem>(entity =>
            {
                entity.ToTable("store_item");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Link)
                    .HasColumnType("character varying")
                    .HasColumnName("link");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.StoreItems)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("store_item_p_id_fkey");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany(p => p.StoreItems)
                    .HasForeignKey(d => d.SId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("store_item_s_id_fkey");
            });

            modelBuilder.Entity<StrAtr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("str_atr");

                entity.Property(e => e.AtrKey)
                    .HasColumnType("character varying")
                    .HasColumnName("atr_key");

                entity.Property(e => e.AtrValue)
                    .HasColumnType("character varying")
                    .HasColumnName("atr_value");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("str_atr_p_id_fkey");
            });

            modelBuilder.Entity<Sub>(entity =>
            {
                entity.ToTable("sub");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.PModel)
                    .HasColumnType("character varying")
                    .HasColumnName("p_model");
            });

            modelBuilder.Entity<SubUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sub_user");

                entity.Property(e => e.SubId).HasColumnName("sub_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Sub)
                    .WithMany()
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sub_user_sub_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sub_user_user_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "user_email_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Coin).HasColumnName("coin");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.LastVisit).HasColumnName("last_visit");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_status_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
