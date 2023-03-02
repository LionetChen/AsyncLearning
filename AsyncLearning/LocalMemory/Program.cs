internal class Program
{
    class ClassA
    {
        public int Variable { get; set; }
    }

    private static void Main(string[] args)
    {
        ClassA heapObject = new ();
        new Thread(new ParameterizedThreadStart(obj => PrintTo30((ClassA)obj!))).Start(heapObject);
        PrintTo30(heapObject);
    }

    private static void PrintTo30(ClassA heapObject)
    {        
        for (int i = 0; i < 10; i++)
        {
            heapObject.Variable++;
            Console.WriteLine($"{i + 1}-{heapObject.Variable}");
        }
    }
}