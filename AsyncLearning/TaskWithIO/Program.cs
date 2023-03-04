// See https://aka.ms/new-console-template for more information
string url = "https://jsonplaceholder.typicode.com/posts";

Task<string> task = Task.Factory.StartNew(() => GetJson(url));
Console.WriteLine($"Content length: {task.Result.Length}");
// Console.WriteLine($"{task.Result}");

url += "/WRONG_URL";

try
{
    Task<string> taskWithException = Task.Factory.StartNew(() => GetJson(url));
    taskWithException.Wait();
}
catch (AggregateException ae)
{
    Console.WriteLine(ae.Message);
    // Exceptions throw within a Task is wrapped into an AggrecatedException and can be caught 
    foreach (var ex in ae.InnerExceptions)
    {
        Console.WriteLine(ex.Message);
    }
}

static string GetJson(string url)
{
    HttpClient client = new ();
    HttpResponseMessage response = client.Send(new HttpRequestMessage(HttpMethod.Get, url));
    response.EnsureSuccessStatusCode();
    return response.Content.ReadAsStringAsync().Result;
}