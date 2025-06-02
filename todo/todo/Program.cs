using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        using var context = new TaskContext();

        context.Database.EnsureCreated();
        
        Console.WriteLine("Database opened");
    }
}