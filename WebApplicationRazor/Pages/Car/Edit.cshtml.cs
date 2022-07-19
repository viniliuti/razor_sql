using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Models.Car thisCar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oi = ConstantCar.cars
                .FirstOrDefault(f => f.Id == id);

            thisCar = oi;

            return Page();
        }
    }
}
