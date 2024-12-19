using Microsoft.AspNetCore.Mvc;
using MomProduct.Web.Models;

namespace MomProduct.Web.Controllers
{
    public class BabyNamesController : Controller
    {
        public ActionResult Index()
        {
            var babyNames = new List<BabyName>
        {
            new BabyName { Name = "Aadit", Meaning = "Peak" },
            new BabyName { Name = "Aarav", Meaning = "A loud sound or thundering" },
            new BabyName { Name = "Aariv", Meaning = "King of wisdom" },
            new BabyName { Name = "Adrit", Meaning = "One worthy of respect" },
            // Add more names as needed
        };

            return View(babyNames);
        }
    }
}
