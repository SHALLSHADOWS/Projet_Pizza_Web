using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet_Web_Pizza.Models;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet_Web_Pizza.Pages
{
    public class MenuPizzaModel : PageModel


    {

        private readonly Projet_Web_Pizza.Data.DataContext _context;

        public MenuPizzaModel(Projet_Web_Pizza.Data.DataContext context)
        {
            _context = context;
        }
       

        public IList<Pizza> Pizza { get; set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
            Pizza = Pizza.OrderBy(p => p.prix).ToList();
        }

    }
}
