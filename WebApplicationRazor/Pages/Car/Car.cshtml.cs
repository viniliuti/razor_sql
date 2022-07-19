using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
    public class CarModel : PageModel
    {
        public List<Models.Car> cars = new()
        {
            new Models.Car {Id=1, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car {Id=2, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car {Id=3, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car {Id=4, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car {Id=5, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
        };
        public void OnGet()
        {
        }
    }
}
