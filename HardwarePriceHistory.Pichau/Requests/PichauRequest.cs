using HardwarePriceHistory.Pichau.Models;
using Newtonsoft.Json;

namespace HardwarePriceHistory.Pichau.Requests;

public class PichauRequest
{
    private readonly string _Address;

    public PichauRequest(string address)
    {
        _Address = address;
    }

    public PichauProduct MakeRequest()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.134 Safari/537.36 Edg/103.0.1264.77");
        var response = client.GetStreamAsync(_Address).Result;

        using var reader = new StreamReader(response);
        string data = reader.ReadToEnd();

        var product = JsonConvert.DeserializeObject<PichauProduct>(data);

        return product;
    }
}