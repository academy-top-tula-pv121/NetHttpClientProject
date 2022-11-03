using Microsoft.Extensions.DependencyInjection;

namespace NetHttpClientProject
{
    internal class Program
    {
        // DependencyInjection
        static async Task Main(string[] args)
        {
            string serverUrl = @"http://efimovlg.beget.tech";

            var services = new ServiceCollection();
            services.AddHttpClient();
            var provider = services.BuildServiceProvider();
            var factory = provider.GetService<IHttpClientFactory>();

            var client = factory?.CreateClient();

            // HttpClient Send/SendAsync
            //using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://efimovlg.beget.tech");
            //using HttpResponseMessage response = await client.SendAsync(request);

            using HttpResponseMessage response = await client.GetAsync(serverUrl);

            Console.WriteLine(response.StatusCode);
            foreach(var header in response.Headers)
            {
                Console.Write($"{header.Key}: ");
                foreach(var value in header.Value)
                    Console.WriteLine(value);
            }

            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            
            // GetStringAsync
            Console.WriteLine(await client.GetStringAsync(serverUrl));

            //for (int i = 0; i < 10; i++)
            //{
            //    //using (var client = new HttpClient(handler, false))
            //    //{
            //    var result = await client.GetAsync("http://yandex.ru");
            //    Console.WriteLine(result.StatusCode);
            //    //}
            //}

        }



        //static HttpClient client = new();
        //static async Task Main(string[] args)
        //{
        //    // share handler
        //    //HttpMessageHandler handler = new HttpClientHandler();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        //using (var client = new HttpClient(handler, false))
        //        //{
        //        using var result = await client.GetAsync("http://yandex.ru");
        //        Console.WriteLine(result.StatusCode);
        //        //}
        //    }
        //}
    }
}