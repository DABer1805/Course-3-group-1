namespace CsvWork;

public class Program
{
    public static void Main(string[] args)
    {
        CsvWorker csvWork = new CsvWorker();
        var data = csvWork.Read("sales.csv");
        foreach (var elem in data)
        {
            Console.WriteLine($"{elem.Date} {elem.Product} {elem.Region} {elem.Quantity} {elem.Price}");
        }
    }
}