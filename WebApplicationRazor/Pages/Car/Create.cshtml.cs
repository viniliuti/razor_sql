using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
	public class CreateModel : PageModel
	{
		[BindProperty]
		public Models.Car? thisCar { get; set; }

		private readonly INotyfService _notyf;
		public CreateModel(INotyfService notyf)
		{
			_notyf = notyf;
		}

		public void OnGet() { }

		public IActionResult OnPost()
		{
			_notyf.Success("Changes saved!");

			int maxId;
			if (ConstantCar.cars.Count == 0)
				maxId = 1;
			else
				maxId = ConstantCar.cars!.Max(m => m.Id) + 1;

			thisCar!.Id = maxId;

			ConstantCar.AddCar(thisCar!);

			return RedirectToPage("./Car");
		}
	}
}
