namespace ReaderWriterLock;

internal class Program
{
    static ReaderWriterLockSlim _readerWriterLockSlim = new();
    static Dictionary<int, string> persons = new();
    static Random _random = new ();

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Task task1 = Task.Factory.StartNew(Read);
        // Task task2 = Task.Factory.StartNew(Write, "Chapter1");
        Task task3 = Task.Factory.StartNew(Read);
        Task task4 = Task.Factory.StartNew(Read);
        Task task5 = Task.Factory.StartNew(Read);
    }

    static void Read()
    {
        for (int i = 0; i < 10; i++)
        {
            _readerWriterLockSlim.EnterReadLock();
            Thread.Sleep(50);
            _readerWriterLockSlim.ExitReadLock();
        }
    }

    static void Write()
    {
        for (int i = 0; i < 10; i++)
        {
            int id = _random.Next(2000, 5000);
            _readerWriterLockSlim.EnterWriteLock();
            persons.Add(i, $"Person {i}");
            _readerWriterLockSlim.ExitWriteLock();
            Thread.Sleep(250);
        }
    }
}
