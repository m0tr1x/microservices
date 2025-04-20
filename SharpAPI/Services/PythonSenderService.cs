using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class PythonSenderService
{
    private readonly HttpClient _httpClient;

    public PythonSenderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendDataAsync(object data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://pyservice:8000/process", content);
        response.EnsureSuccessStatusCode(); 
    }
}