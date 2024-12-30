using Microsoft.AspNetCore.Mvc;
using MomProduct.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MomProduct.Web.Controllers
{
    public class BlogTemplatesController : Controller
    {

        //Hosted web API REST Service base url
        string Baseurl = "https://localhost:7129/";
        public async Task<ActionResult> Index()
        {
            List<BlogTemplate> BlogInfo = new List<BlogTemplate>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/BlogTemplate/GetAllBlogTemplates");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var BlogResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    BlogInfo = JsonConvert.DeserializeObject<List<BlogTemplate>>(BlogResponse);
                }
                //returning the employee list to view
                return View(BlogInfo);
            }
        }
        //public ActionResult Index()
        //{
        //    var tips = new List<BlogType>
        //{


        //    new BlogType { Id = 1, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
        //    new BlogType { Id = 2, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
        //    new BlogType { Id = 3, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
        //    new BlogType { Id = 4, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
        //    new BlogType { Id = 5, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" }
        //};

        //    return View(tips);
        //}
    }
}
