// See https://aka.ms/new-console-template for more information


public static class Program
{
    static object _lock = new();

    static void Main(string[] args)
    {
        // The parent lock holds the resource
        lock (_lock)
        {
            DoSomething();
        }
    }

    private static void DoSomething()
    {
        // Nested lock. Same thread so taking the lock again without issue - reentrant lock
        lock (_lock)
        {
            Task.Delay(2000);
            AnotherMethod();
        }
    }

    private static void AnotherMethod()
    {
        // Nested lock. Again, same thread taking the lock
        lock (_lock)
        {
            Task.Delay(2000);
        }
    }
}