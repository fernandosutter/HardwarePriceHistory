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
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
        client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "Chromium;v=124, Google Chrome;v=124, Not-A.Brand;v=99");
        client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
        //client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform:", "'Windows'");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
        client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");

        try
        {
            var response = client.GetStreamAsync(_address).Result;
            using var reader = new StreamReader(response);
            string data = reader.ReadToEnd();

            var products = JsonConvert.DeserializeObject<PichauProductData>(data);
            return products;
        }
        catch (Exception e)
        {
            return null;
        }
        
    }
}