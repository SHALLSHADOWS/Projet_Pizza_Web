using Microsoft.AspNetCore.Mvc;
using Projet_Web_Pizza.Data;
using Projet_Web_Pizza.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet_Web_Pizza.Pages.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        DataContext dataContext;
        public ApiController(DataContext dataContext) { 
        this.dataContext = dataContext;
        
        
        }
        [HttpGet]
        [Route("GetPizzas")]
        public ActionResult<string> GetPizzas()
        {
           // var pizza = new Pizza() { nom = "paul", vegetarienne = false, prix = 12, ingredients = "sauce, tomates, fruit vert, orange" };
           var  pizza = dataContext.Pizzas.ToList();
            return Json(pizza);
        }


    }
}
