internal class Program
{
    private static void Main(string[] args)
    {
        Thread thread = new (PrintHelloWorld);
        thread.Start();
        // Waits for the thread to finish before continuing
        thread.Join();
        Console.WriteLine("Following Hello world");
    }

    private static void PrintHelloWorld(object? obj)
    {
        Console.WriteLine("Hello world");
        Thread.Sleep(5000);
    }
}