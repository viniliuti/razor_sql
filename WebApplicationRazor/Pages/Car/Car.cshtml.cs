using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
	public class CarModel : PageModel
	{
		public List<Models.Car> cars = ConstantCar.cars;

		public void OnGet()
		{
		}

		public IActionResult OnPostShowPrice(int? id)
		{
			if (id == null)
				return NotFound();

			if (!ConstantCar.cars.Exists(e => e.Id == id))
				return NotFound();

			var thisCar = ConstantCar.cars.FirstOrDefault(f => f.Id == id);
			thisCar.ShowPrice = !thisCar.ShowPrice;
			ConstantCar.UpdateCar(thisCar.Id, thisCar);

			return RedirectToPage();
		}

		public IActionResult OnPostResetCarsList()
		{
			System.Console.WriteLine("oias");
			ConstantCar.ResetBaseCars();

			return RedirectToPage();
        }
	}
}
