namespace todo;
class TaskList
{
    List<Task> todo = new List<Task>();
    List<Task> inProgress = new List<Task>();
    List<Task> completed = new List<Task>();
    
    publid void Add(Task t)
    {
        switch(t.priority)
        {
            case "todo":
                todo.Add(t);
                break;
            case "inProgress":
                inProgress.Add(t);
                break;
            case "completed":
                completed.Add(t);
                break;
        }
        //add linq statement here to add to sqlite as well
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