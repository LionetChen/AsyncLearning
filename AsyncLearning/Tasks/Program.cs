// See https://aka.ms/new-console-template for more information

Task task = new (SimpleMethod);
Task<string> taskWithReturn = new (MethodReturnsString);

task.Start();
taskWithReturn.Start();
Console.WriteLine(taskWithReturn.Result);

// If we don't wait or use Console.ReadKey() here, process will exit because Task is by default from ThreadPool - a background thread
task.Wait();
Console.ReadKey();

void SimpleMethod()
{
    Thread.Sleep(2000);
    Console.WriteLine("Hello");
}


string MethodReturnsString()
{
    return "I'm a string";
}