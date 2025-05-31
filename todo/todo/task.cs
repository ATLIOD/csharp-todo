using System.Reflection;

namespace todo;

class Task
{
    public Task(int id, string newTitle, string newPriority)
    {
        this.Id = id;
        this.Title = newTitle;
        this.priotiry = newPriority;
        this.CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        this.UpdatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
    private int Id{
        get;
        set;
    }

    public required string Title
    {
        get;
        set;
    }
    
    public required string Priority
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
            Priority = newPriority;
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
            Title = newTitle;
        }
        
    }

}