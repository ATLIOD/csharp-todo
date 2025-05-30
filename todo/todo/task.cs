namespace todo;

class Task
{
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
    
    public DateTime CreatedAt
    {
        get;
        set;
    }
    
    public DateTime UpdatedAt
    {
        get;
        set;
    }

    public void UpdatePriority(string newPriority)
    {
        Priority = newPriority;
    }
    

}