using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LinqDemo2.DAL;

public partial class BrightDb3Context : DbContext
{
    public BrightDb3Context()
    {
    }

    public BrightDb3Context(DbContextOptions<BrightDb3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Password).HasDefaultValueSql("(N'')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
