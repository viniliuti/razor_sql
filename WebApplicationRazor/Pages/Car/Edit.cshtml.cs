using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
	public class EditModel : PageModel
	{
		[BindProperty]
		public Models.Car? thisCar { get; set; }

		private readonly INotyfService _notyf;
		public EditModel(INotyfService notyf)
		{
			_notyf = notyf;
		}

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				_notyf.Error("Id: " + id + " not found.");
				return RedirectToPage("./Car");
			}

			if (!ConstantCar.cars.Exists(e => e.Id == id))
			{
				_notyf.Error("Car with Id: " + id + " doesn`t exist.");
				return RedirectToPage("./Car");
			}

			thisCar = ConstantCar.cars
				.FirstOrDefault(f => f.Id == id);

			return Page();
		}

		public IActionResult OnPost(int? id)
		{
			if (id == null)
				return IdNotFound(id);

			var getCar = ConstantCar.cars
				.FirstOrDefault(f => f.Id == id);

			if (getCar == null)
				return CarNotFound(id);

			ConstantCar.UpdateCar(id.Value, thisCar!);

			_notyf.Success("Changes saved!");

			return RedirectToPage();
		}

		private IActionResult IdNotFound(int? id)
		{
			_notyf.Error("Id: " + id + " not found.");
			return RedirectToPage("./Car");
		}

		private IActionResult CarNotFound(int? id)
		{
			_notyf.Error("Car with Id: " + id + " doesn`t exist.");
			return RedirectToPage("./Car");
		}
	}
}
