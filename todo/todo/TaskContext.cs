using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
    public DbSet<todo.TaskItem> Tasks => Set<todo.TaskItem>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("Data Source=tasks.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<todo.TaskItem>()
            .HasCheckConstraint("CK_Priority", "priority IN ('todo', 'inProgress', 'completed')");
    }
}