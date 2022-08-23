using HardwarePriceHistory.Pichau.Models;
using Newtonsoft.Json;

namespace HardwarePriceHistory.Pichau.Requests;

public class PichauRequest
{
    private readonly string _address;

    public PichauRequest(string address)
    {
        _address = address;
    }

    public PichauProductData? MakeRequest()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.134 Safari/537.36 Edg/103.0.1264.77");
        var response = client.GetStreamAsync(_address).Result;

        using var reader = new StreamReader(response);
        string data = reader.ReadToEnd();

        var products = JsonConvert.DeserializeObject<PichauProductData>(data);

        return products;
    }
}