namespace hw_cSH_14;

class Program
{
    static void Main(string[] args)
    {
        const string path = "ip_data.json";
        
        // Query.GetLocationByIp("62.16.8.251", path);
        // Query.GetLocationByIp("8.8.4.4", path);
        Query.GetLocationByIp("32.16.8.221", path);

        Console.ReadKey();
    }
}