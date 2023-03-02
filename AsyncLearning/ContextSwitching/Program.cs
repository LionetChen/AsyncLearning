internal class Program
{
    private static void Main(string[] args)
    {
        // Worker thread
        Thread thread = new(WriteUsingNewThread)
        {
            Name = "Worker One"
        };
        thread.Start();

        // Main thread
        Thread.CurrentThread.Name = "Main thread with name";
        for (int i = 0; i < 1000; i++)
        {
            Console.Write($"A{i:D4} ");
        }

        Console.WriteLine("\r\nObserver, A and Z are intertwined and context switch happens at different index each time you run.");
    }

    private static void WriteUsingNewThread(object? obj)
    {
        for (int i = 0; i < 1000; i++)
        {
            Console.Write($"Z{i:D4} ");            
        }
    }
}