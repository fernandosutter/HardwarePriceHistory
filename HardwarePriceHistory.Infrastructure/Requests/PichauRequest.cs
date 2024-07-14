using HardwarePriceHistory.Core.Abstractions;
using HardwarePriceHistory.Domain.Models;
using Newtonsoft.Json;

namespace HardwarePriceHistory.Infrastructure.Requests;

public class PichauRequest
{
    private readonly string _address;

    public PichauRequest(string address)
    {
        _address = address;
    }

    public Result<PichauProductData> MakeRequest()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");
        client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "Chromium;v=124, Google Chrome;v=124, Not-A.Brand;v=99");
        client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?0");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
        client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
        client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
        client.DefaultRequestHeaders.Add("Referer", "https://www.pichau.com.br/hardware/placa-m-e");
        client.DefaultRequestHeaders.Add("Cookie",
            "cf_clearance=yZe3yO4CMQKFt3HbabYwHON9SjsizKbol6.92ng6J_k-1717621497-1.0.1.1-k8weYI8NUAk1LyGE_wCZWhap2SFGssP7yZPPWdOIWyu5mMwVlr6_YfsHFoQX05q_sevzz5izjGCfr5.pF8FUIQ; __cf_bm=7VB9Tzt_HSwXt_Q6c4w4N01VNlT63E9HsRdrXffnb78-1717622530-1.0.1.1-N2cN3KtpIMuHJCJJXqOqUPUZn7_wtCZzPMxBl0hLrEciNlGS1bGrFtZbt9paSWizVT2Jy3ve0JBClNs.qlaNVg");

        try
        {
            var response = client.GetStreamAsync(_address).Result;
            using var reader = new StreamReader(response);
            string data = reader.ReadToEnd();

            var products = JsonConvert.DeserializeObject<PichauProductData>(data);
            
            return products is null || products.Data is null
                ? Result<PichauProductData>.Failure("Pichau request failure.")
                : Result<PichauProductData>.Success(products);
        }
        catch (Exception e)
        {
            return Result<PichauProductData>.Failure($"Pichau request failure. {e.Message}");
        }
    }
}