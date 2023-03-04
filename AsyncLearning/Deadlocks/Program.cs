namespace Deadlocks;

internal class Program
{
    static object _lock1 = new();
    static object _lock2 = new();

    static void Main(string[] args)
    {
        new Thread(() =>
        {
            lock (_lock1)
            {
                Console.WriteLine($"{nameof(_lock1)} obtained");
                Thread.Sleep(2000);
                lock (_lock2)
                {
                    Console.WriteLine($"{nameof(_lock2)} obtained");
                }
            }
        }).Start();

        lock (_lock2)
        {
            Console.WriteLine($"Main thread obtained {nameof(_lock2)}");
            Thread.Sleep(100);
            lock ( _lock1) // This'll wait for the worker thread to finish which never happens
            {

            }
        }
    }
}
