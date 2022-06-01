using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZolotiTelenok
{
    public partial class ZTDBContext : DbContext
    {
        public ZTDBContext()
        {
        }

        public ZTDBContext(DbContextOptions<ZTDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Запись> Записьs { get; set; } = null!;
        public virtual DbSet<Клиент> Клиентs { get; set; } = null!;
        public virtual DbSet<Машина> Машинаs { get; set; } = null!;
        public virtual DbSet<Работник> Работникs { get; set; } = null!;
        public virtual DbSet<Услуги> Услугиs { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GREB1VK\\SQLEXPRESS;Initial Catalog=ZTDB;Integrated Security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Запись>(entity =>
            {
                entity.HasKey(e => e.ИдЗаписи);

                entity.ToTable("Запись");

                entity.HasIndex(e => e.ИдМашины, "IX_FK_Запись_Машина");

                entity.HasIndex(e => e.ИдРаботнка, "IX_FK_Запись_Работник");

                entity.HasIndex(e => e.ИдУслуги, "IX_FK_Запись_Услуги");

                entity.Property(e => e.ИдЗаписи).HasColumnName("ИД_Записи");

                entity.Property(e => e.Дата).HasColumnType("date");

                entity.Property(e => e.ИдМашины).HasColumnName("ИД_Машины");

                entity.Property(e => e.ИдРаботнка).HasColumnName("ИД_Работнка");

                entity.Property(e => e.ИдУслуги).HasColumnName("ИД_Услуги");

                entity.Property(e => e.Сумма).HasColumnType("money");

                entity.HasOne(d => d.ИдМашиныNavigation)
                    .WithMany(p => p.Записьs)
                    .HasForeignKey(d => d.ИдМашины)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Запись_Машина");

                entity.HasOne(d => d.ИдРаботнкаNavigation)
                    .WithMany(p => p.Записьs)
                    .HasForeignKey(d => d.ИдРаботнка)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Запись_Работник");

                entity.HasOne(d => d.ИдУслугиNavigation)
                    .WithMany(p => p.Записьs)
                    .HasForeignKey(d => d.ИдУслуги)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Запись_Услуги");
            });

            modelBuilder.Entity<Клиент>(entity =>
            {
                entity.HasKey(e => e.ИдКлиента);

                entity.ToTable("Клиент");

                entity.Property(e => e.ИдКлиента).HasColumnName("ИД_Клиента");

                entity.Property(e => e.Время).HasColumnType("datetime");

                entity.Property(e => e.Имя).HasMaxLength(50);

                entity.Property(e => e.Телефон).HasMaxLength(12);

                entity.Property(e => e.Фамилия).HasMaxLength(50);
            });

            modelBuilder.Entity<Машина>(entity =>
            {
                entity.HasKey(e => e.ИдМашины);

                entity.ToTable("Машина");

                entity.Property(e => e.ИдМашины).HasColumnName("ИД_Машины");

                entity.Property(e => e.Марка).HasMaxLength(50);

                entity.Property(e => e.Модель).HasMaxLength(50);
            });

            modelBuilder.Entity<Работник>(entity =>
            {
                entity.HasKey(e => e.ИдРаботника);

                entity.ToTable("Работник");

                entity.Property(e => e.ИдРаботника).HasColumnName("ИД_Работника");

                entity.Property(e => e.Имя).HasMaxLength(50);

                entity.Property(e => e.Отчество).HasMaxLength(50);

                entity.Property(e => e.Телефон).HasMaxLength(50);

                entity.Property(e => e.Фамилия).HasMaxLength(50);
            });

            modelBuilder.Entity<Услуги>(entity =>
            {
                entity.HasKey(e => e.ИдУслуги);

                entity.ToTable("Услуги");

                entity.Property(e => e.ИдУслуги).HasColumnName("ИД_Услуги");

                entity.Property(e => e.Наименование).HasMaxLength(50);

                entity.Property(e => e.Цена).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
