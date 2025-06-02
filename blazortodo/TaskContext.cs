using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
    public DbSet<blazortodo.TaskItem> Tasks => Set<blazortodo.TaskItem>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=tasks.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<blazortodo.TaskItem>()
            .HasCheckConstraint("CK_Priority", "priority IN ('todo', 'inProgress', 'completed')");
    }
}