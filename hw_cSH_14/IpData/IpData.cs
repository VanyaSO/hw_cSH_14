namespace hw_cSH_14;

public struct IpData
{
    public string Country { get; set; }
    public string Region { get; set; }
    public string City { get; set; }

    public IpData(string country, string region, string city)
    {
        Country = country;
        Region = region;
        City = city;
    }
}