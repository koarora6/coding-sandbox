using Microsoft.AspNetCore.Mvc;
using SimpleUnitTestingApp.Models;
using System.Diagnostics;

namespace SimpleUnitTestingApp.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource dataSource = new ProductDataSource();
       public ViewResult Index()
        {
            return View(dataSource.Products);
        }
    }
}