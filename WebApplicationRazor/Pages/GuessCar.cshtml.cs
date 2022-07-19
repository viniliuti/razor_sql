using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationRazor.Models;

namespace WebApplicationRazor.Pages
{
    public class GuessCarModel : PageModel
    {
        public List<Models.Car> cars = new()
        {
            new Models.Car { Id=1, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=2, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=3, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=4, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=5, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
        };

        public decimal _price { get; set; }

        public void OnGet()
        {
        }

        public void OnPostTryButton()
        {
            Console.WriteLine("funciona");
        }
    }
}
