internal class Program
{
    static bool _isCompleted = false;
    static object _lockIsCompleted = new object();

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread.CurrentThread.Name = "Main thread with name";

        // Worker thread
        Thread thread = new(HelloWorldThread);
        thread.Name = "Worker Thread";

        thread.Start();
        HelloWorldThread();

    }

    static void HelloWorldThread()
    {
        lock (_lockIsCompleted)
        {
            if (!_isCompleted)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: I shall say this only once");
                _isCompleted = true;
            }
        }
    }
}