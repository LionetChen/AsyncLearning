// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Random rand = new ();
Account account = new Account(20000);

List<Task> tasks = new List<Task>();

try
{
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    tasks.Add(Task.Run(() => account.Withdraw(rand.Next(1500, 2000))));
    Task.WaitAll(tasks.ToArray());
}
catch (AggregateException ae)
{
    Console.WriteLine(ae.Message);
}

Console.WriteLine($"Contention times = {Monitor.LockContentionCount}");

public class Account
{
    private int _balance;
    private static object _balanceLock = new();

    public Account(int balance)
    {
        _balance = balance;
    }

    public int Withdraw(int amount)
    {
        if (_balance < 0)
        {
            throw new Exception("Account overdrawn!");
        }

        // lock and try(Monitor.Enter)/(Exit) is exactly the same
        //Monitor.Enter(_balanceLock);
        //try
        lock(_balanceLock)
        {
            if (_balance >= amount)
            {
                Console.WriteLine($"Withdrawn {amount} Balance={_balance}");
                // Put this line after the Console.WriteLine. Otherwise exception will not be thrown even without locks..
                _balance -= amount;
                return _balance;
            }
            else
            {
                Console.WriteLine($"Failed to withdrawn {amount}. Balance={_balance}");
                return 0;
            }
        }
        //finally
        //{
        //    Monitor.Exit(_balanceLock);
        //}
    }
}