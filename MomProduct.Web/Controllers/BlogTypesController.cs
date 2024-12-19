using Microsoft.AspNetCore.Mvc;
using MomProduct.Web.Models;

namespace MomProduct.Web.Controllers
{
    public class BlogTypesController : Controller
    {
        public ActionResult Index()
        {
            var tips = new List<BlogType>
        {
            new BlogType { Id = 1, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
            new BlogType { Id = 2, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
            new BlogType { Id = 3, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
            new BlogType { Id = 4, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" },
            new BlogType { Id = 5, Title = "5 Helpful Tips for Growing Healthy Succulents", ImagePath = "https://wallpaperaccess.com/full/5715141.jpg" }
        };

            return View(tips);
        }
    }
}
