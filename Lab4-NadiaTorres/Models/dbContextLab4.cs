using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab4_NadiaTorres.Models;

public partial class dbContextLab4 : DbContext
{
    public dbContextLab4()
    {
    }

    public dbContextLab4(DbContextOptions<dbContextLab4> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detallesorden> Detallesordens { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tiendadb;Username=postgres;Password=tecsup");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Categoriaid).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Clienteid).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Fechacreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallesorden>(entity =>
        {
            entity.HasKey(e => e.Detalleid).HasName("detallesorden_pkey");

            entity.ToTable("detallesorden");

            entity.Property(e => e.Detalleid).HasColumnName("detalleid");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Ordenid).HasColumnName("ordenid");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Productoid).HasColumnName("productoid");

            entity.HasOne(d => d.Orden).WithMany(p => p.Detallesordens)
                .HasForeignKey(d => d.Ordenid)
                .HasConstraintName("fk_detallesorden_ordenes");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallesordens)
                .HasForeignKey(d => d.Productoid)
                .HasConstraintName("fk_detallesorden_productos");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.Ordenid).HasName("ordenes_pkey");

            entity.ToTable("ordenes");

            entity.Property(e => e.Ordenid).HasColumnName("ordenid");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Fechaorden)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaorden");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("fk_ordenes_clientes");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Pagoid).HasName("pagos_pkey");

            entity.ToTable("pagos");

            entity.Property(e => e.Pagoid).HasColumnName("pagoid");
            entity.Property(e => e.Fechapago)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechapago");
            entity.Property(e => e.Metodopago)
                .HasMaxLength(50)
                .HasColumnName("metodopago");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Ordenid).HasColumnName("ordenid");

            entity.HasOne(d => d.Orden).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Ordenid)
                .HasConstraintName("fk_pagos_ordenes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Productoid).HasName("productos_pkey");

            entity.ToTable("productos");

            entity.Property(e => e.Productoid).HasColumnName("productoid");
            entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoriaid)
                .HasConstraintName("fk_productos_categorias");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
