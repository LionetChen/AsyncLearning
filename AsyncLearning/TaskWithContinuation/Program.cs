Task<string> antecedent = new(() =>
{
    Task.Delay(2000).Wait();
    return DateTime.Today.ToShortDateString();
});

// If antecedent is not started, continuation.Result will stuck and result in a deadlock
antecedent.Start();

// Define the continuation. But it will not execute until antecedent is finished.
Task<string> continuation = antecedent.ContinueWith(
    ant =>
    {
        return $"Today is {ant.Result}";
    }
);

Console.WriteLine("This should be shown before any tasks are done.");
Console.WriteLine(continuation.Result);