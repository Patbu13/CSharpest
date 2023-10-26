namespace CSharpest.Classes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using static System.Net.WebRequestMethods;


//	Last modified by: Vivian D'Souza
//	Windows Prog 547
//	Last Updated : 10/25/23

//  Interaction with the main page of the storefront (not sure if will need)

// Make this a singleton. 
public static class Storefront
{
    public static Dictionary<Item, int> Stock {  get; set; }
    public static string url = "https://localhost:7055/Item/GetAllItems/";
    public static async void DisplayItems()
    {
        HttpClient client = new HttpClient();
        //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);
        ////client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //message.Content = JsonContent.Create<Item>(item);
        //HttpResponseMessage response = await client.SendAsync(message);

        string text = await client.GetStringAsync(url);
    }


}
