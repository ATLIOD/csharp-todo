using System.Data.SQLite;

namespace todo;
class TaskList
{

    public TaskList(TaskContext context)
    {
        var tasks = context.Tasks.ToList();

        todo = tasks.Where(t => t.Priority == "todo").ToList();
        inProgress = tasks.Where(t => t.Priority == "inProgress").ToList();
        complete = tasks.Where(t => t.Priority == "complete").ToList();
    }
    List<TaskItem> todo = new List<TaskItem>();
    List<TaskItem> inProgress = new List<TaskItem>();
    List<TaskItem> complete = new List<TaskItem>();
    
    public void Add(string title, string priority)
    {
        TaskItem t = new TaskItem(title, priority);
        switch(t.Priority)
        {
            case "todo":
                todo.Add(t);
                break;
            case "inProgress":
                inProgress.Add(t);
                break;
            case "completed":
                complete.Add(t);
                break;
        }
        
        using var context = new TaskContext();
        context.Tasks.Add(t);
        context.SaveChanges();
    }
    
    private void DatabaseAdd(int id, string newTitle, string newPriority)
    {
        
    }

    public void Remove(TaskItem t)
    {
        switch(t.Priority)
        {
            case "todo":
                todo.Remove(t);
                break;
            case "inProgress":
                inProgress.Remove(t);
                break;
            case "completed":
                complete.Remove(t);
                break;
        }
        
        using var context = new TaskContext();
        context.Tasks.Add(t);
        context.SaveChanges();
    }
}