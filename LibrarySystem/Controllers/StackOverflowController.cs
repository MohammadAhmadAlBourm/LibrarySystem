using LibrarySystem.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace LibrarySystem.Controllers
{
    public class StackOverflowController : Controller
    {
        private readonly string stackOverflowUrl = "https://localhost:7268/";

        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(stackOverflowUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/books");
                
                if(response.IsSuccessStatusCode)
                {
                    var book = response.Content.ReadAsStringAsync().Result;
                    books = JsonConvert.DeserializeObject<List<Book>>(book);
                }

                return View(books);
            }
        }


        //HttpClient client = new HttpClient()
        //{
        //    BaseAddress = new Uri(stackOverflowUrl)
        //};
        //HttpResponseMessage response = await client.GetAsync(sta);
        //string responseString = await response.Content.ReadAsStringAsync();
        //var responseObject = JsonConvert.DeserializeObject<StackOverflowQuestion>(responseString);


    }
}
