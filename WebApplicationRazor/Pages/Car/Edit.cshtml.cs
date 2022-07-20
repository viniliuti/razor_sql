using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public Models.Car? thisCar { get; set; }

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			if (!ConstantCar.cars.Exists(e => e.Id == id))
				return NotFound();

			thisCar = ConstantCar.cars
				.FirstOrDefault(f => f.Id == id);

			return Page();
		}
	}
}
