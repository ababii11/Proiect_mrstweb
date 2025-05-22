using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Recipe;


namespace MRSTWeb.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            var bl = new BusinessLogic();
            
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Recipes
        public ActionResult Recipes()
        {
            
            return View();
        }

        // GET: Recipe Details
        public ActionResult RecipeDetails()
        {
            
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}