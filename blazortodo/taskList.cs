using System.Data.SQLite;

namespace blazortodo;

class TaskList
{

    public TaskList()
    {
        _context.Database.EnsureCreated();
        var tasks = _context.Tasks.ToList();

        todo = tasks.Where(t => t.Priority == "todo").ToList();
        inProgress = tasks.Where(t => t.Priority == "inProgress").ToList();
        complete = tasks.Where(t => t.Priority == "completed").ToList();
    }
    
    private readonly TaskContext _context =  new TaskContext();       
    
    public List<TaskItem> todo = new List<TaskItem>();
    public List<TaskItem> inProgress = new List<TaskItem>();
    public List<TaskItem> complete = new List<TaskItem>();
    
    public void Add(string title, string priority)
    {
        System.Diagnostics.Debug.WriteLine("tasklist/add called");
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
        
        _context.Tasks.Add(t);
        _context.SaveChanges();
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
        
        _context.Tasks.Add(t);
        _context.SaveChanges();
    }
}