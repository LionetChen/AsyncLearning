internal class Program
{
    private static void Main(string[] args)
    {
        TriggerException();
    }

    private static void TriggerException()
    {
        // Exception handling is per thread.
        try
        {
            new Thread(() => {
                throw new NotImplementedException();
            }).Start();            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}