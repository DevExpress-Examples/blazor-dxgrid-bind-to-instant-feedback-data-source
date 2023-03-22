using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InstantFeedback.Models;
public partial class NorthwindContext : DbContext {
    public NorthwindContext() {}
    public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) {}
    public virtual DbSet<Order> Orders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Northwind;Integrated Security=true");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        modelBuilder.Entity<Order>(entity => {
            entity.HasIndex(e => e.OrderDate, "OrderDate");
            entity.HasIndex(e => e.ShippedDate, "ShippedDate");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Freight)
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShipCity).HasMaxLength(15);
            entity.Property(e => e.ShipCountry).HasMaxLength(15);
            entity.Property(e => e.ShipName).HasMaxLength(40);
            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
