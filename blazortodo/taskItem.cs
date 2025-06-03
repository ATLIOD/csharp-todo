using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace blazortodo;

public class TaskItem
{
    public TaskItem()
    {
    }

    public TaskItem(int id, string newTitle, string newPriority)
    {
        Id = id;
        Title = newTitle;
        Priority = newPriority;
        CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
    public TaskItem(string newTitle, string newPriority)
    {
        Title = newTitle;
        Priority = newPriority;
        CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
    
    public int Id{
        get;
        set;
    }

    public string? Title
    {
        get;
        set;
    }
    
    public string? Priority
    {
        get;
        set;
    }
    
    public long CreatedAt
    {
        get;
        set;
    }
    
    public long UpdatedAt
    {
        get;
        set;
    }

    public void UpdatePriority(string newPriority)
    {
        if (newPriority == Priority)
        {
            throw new ApplicationException("Priority is already set");
        }
        else if (newPriority != "todo" && newPriority != "inProgress" && newPriority != "completed")
        {
            throw new ApplicationException("Entered value is not a valid priority. Priority must be todo, inProgress, or completed");
        }
        else
        {
            using var context = new TaskContext();
            Priority = newPriority;
            UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            context.SaveChanges();   
        }
    }

    public void UpdateTitle(string newTitle)
    {
        if (newTitle == Title)
        {
            throw new ApplicationException("Title is already set as the value entered");
        }
        else
        {
            using var context = new TaskContext();
            Title = newTitle;
            context.SaveChanges();
        }
        
    }

}