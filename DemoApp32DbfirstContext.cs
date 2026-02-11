using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.DBFirst;

public partial class DemoApp32DbfirstContext : DbContext
{
    public DemoApp32DbfirstContext()
    {
    }

    public DemoApp32DbfirstContext(DbContextOptions<DemoApp32DbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailyTask> DailyTasks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DemoApp.32.DBFirst");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyTask>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.DailyTasks)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_DailyTasks_Employees");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
