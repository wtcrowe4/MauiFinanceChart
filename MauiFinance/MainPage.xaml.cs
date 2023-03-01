using System.Diagnostics;
using System.Windows.Input;

namespace MauiFinance;

public partial class MainPage : ContentPage
{


    
	public MainPage()
	{
        InitializeComponent();
        GetStocks();
        
	}

    
    public ICommand GetStocksCommand { get; }



   
    
    // Http request for stocks data
    private static async void GetStocks()
    {
        var api_key = Environment.GetEnvironmentVariable("RAPIDAPI_KEY");
        Debug.WriteLine(api_key);
        var searchTerm = "microsoft";
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/auto-complete?q={searchTerm}"),
            Headers =
            {
                { "X-RapidAPI-Key", "api_key" },
                { "X-RapidAPI-Host", "yh-finance.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(body);
            Debug.WriteLine(api_key);
        }


    }





}

