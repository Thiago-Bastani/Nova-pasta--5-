using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;
using Task = Models.Task;

namespace Database;

public partial class GoalsDbContext : DbContext
{
    public GoalsDbContext()
    {
    }

    public GoalsDbContext(DbContextOptions<GoalsDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Database/goals.db");

    public virtual DbSet<Goal> Goals { get; set; }
    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Task>().HasOne(t => t.Goal).WithMany(g => g.Tasks).HasForeignKey(t => t.GoalId);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
