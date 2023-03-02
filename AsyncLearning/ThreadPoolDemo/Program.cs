internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Processor count = {Environment.ProcessorCount}");
        // Processor count, which is the default
        ThreadPool.SetMinThreads(Environment.ProcessorCount, Environment.ProcessorCount);
        // Set to: at least the processor count
        ThreadPool.SetMaxThreads(Environment.ProcessorCount * 2, Environment.ProcessorCount * 2);



        Employee employee = new("Joe", "Northwind");

        DisplayEmployeeInfo(employee);
        ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

        // Wait for execution
        Console.ReadKey();
        DisplayEmployeeInfo(employee);
    }

    private static void DisplayEmployeeInfo(object? state)
    {
        Employee employee = (state as Employee)!;
        Console.WriteLine($"ThreadPool: {Thread.CurrentThread.IsThreadPoolThread} {employee.Name} {employee.CompanyName}");
    }

    class Employee
    {
        public Employee(string name, string companyName)
        {
            Name = name;
            CompanyName = companyName;
        }

        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}