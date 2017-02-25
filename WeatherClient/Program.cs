// client for StockPrice RESTful web service

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace CAPreperation.Models
{
    // test
    class Program
    {
        // RunAsync awaits results from async methods so must be async itself
        static async Task List()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())                                            // Dispose() called autmatically in finally block
                {
                    client.BaseAddress = new Uri("http://localhost:54804/");                             // base URL for API Controller i.e. RESTFul service
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml
                    HttpResponseMessage response = await client.GetAsync("api/Weather/weatherlist");                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var listings = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var listing in listings)
                        {
                            Console.WriteLine(listing.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task City()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())                                            // Dispose() called autmatically in finally block
                {
                    Console.WriteLine("Enter the city you wish to check");
                    string city = Console.ReadLine();
                    client.BaseAddress = new Uri("http://localhost:54804/");                             // base URL for API Controller i.e. RESTFul service
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml
                    HttpResponseMessage response = await client.GetAsync("api/Weather/city/" + city);                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var listings = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var listing in listings)
                        {
                            Console.WriteLine(listing.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task Warning()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())                                            // Dispose() called autmatically in finally block
                {
                    client.BaseAddress = new Uri("http://localhost:54804/");                             // base URL for API Controller i.e. RESTFul service
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml
                    HttpResponseMessage response = await client.GetAsync("api/Weather/warning");                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var listings = await response.Content.ReadAsAsync<IEnumerable<Weather>>();
                        foreach (var listing in listings)
                        {
                            Console.WriteLine(listing.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static async Task Update()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())                                            // Dispose() called autmatically in finally block
                {
                    Console.WriteLine("Enter the city to update");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter new Temp");
                    int temp = Convert.ToInt32(Console.ReadLine());

                    Weather weatherUpdate = new Weather()
                    {
                        City = city,
                        Condition = Conditions.CLOUDY,
                        Temperature = temp,
                        WeatherWarning = false,
                        WindSpeed = 10
                    };

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(weatherUpdate);

                    Console.WriteLine(json);

                    client.BaseAddress = new Uri("http://localhost:54804/");                             // base URL for API Controller i.e. RESTFul service
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Weather/update", weatherUpdate);                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                            Console.WriteLine(response.StatusCode);  
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.RequestMessage);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        // kick off
        static void Main()
        {
            int selection = 0;
            while (selection != -1)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("1 - List All");
                Console.WriteLine("2 - City");
                Console.WriteLine("3 - Weather Warning");
                Console.WriteLine("4 - Update");
                Console.WriteLine("===================================");
                selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Task result = List();
                        result.Wait();
                        break;
                    case 2:
                        Task resultCity = City();
                        resultCity.Wait();
                        break;
                    case 3:
                        Task resultWarning = Warning();
                        resultWarning.Wait();
                        break;
                    case 4:
                        Task resultUpdate = Update();
                        resultUpdate.Wait();
                        break;


                }
            }
        }
    }
}
