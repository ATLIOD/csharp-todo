namespace todo;
class TaskList
{
    List<Task> todo = new List<Task>();
    List<Task> inProgress = new List<Task>();
    List<Task> completed = new List<Task>();
    private int NextID;
    
    publid void Add(string title, string priority)
    {
        Task t = new Task(NextID, title, priority);
        switch(t.priority)
        {
            case "todo":
                todo.Add(t);
                NextID++;
                break;
            case "inProgress":
                inProgress.Add(t);
                NextID++;
                break;
            case "completed":
                completed.Add(t);
                NextID++;
                break;
        }
        //add linq statement here to add to sqlite as well
    }

    private void DatabaseAdd(int id, string newTitle, string newPriority)
    {
        
    }

    public void Remove(Task t)
    {
        switch(t.priority)
        {
            case "todo":
                todo.Remove(t);
                break;
            case "inProgress":
                inProgress.Remove(t);
                break;
            case "completed":
                completed.Remove(t);
                break;
        }
        //add linq statement here to remove in sqlite as well
    }
}