using System.ComponentModel.DataAnnotations;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationRazor.Pages.Car
{
	public class GuessPriceModel : PageModel
	{
		private readonly INotyfService _notyf;

		[BindProperty]
		public Models.Car? thisCar { get; set; }

		[BindProperty]
		[RegularExpression(@"^(\d+)(?:\.(\d{1,2}))?$")]
		[Range(0.01, 9999999999)]
		public decimal _price { get; set; }

		public GuessPriceModel(INotyfService notyf)
		{
			_notyf = notyf;
		}

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			UpdateThisCar(id);

			return Page();
		}

		public IActionResult OnPostTryButton(int? id)
		{
			UpdateThisCar(id);

			if (_price <= thisCar.Price + 5000
				& _price >= thisCar.Price - 5000)
			{
				_notyf.Success("You guessed the price correctly!!");
			}
			else
			{
				_notyf.Error("That`s not the price. Please try again.");
			}

			return RedirectToPage();
		}
		private void UpdateThisCar(int? id)
		{
			var getCar = ConstantCar.cars
				.Exists(f => f.Id == id);

			if (getCar)
			{
				thisCar = ConstantCar.cars.FirstOrDefault(f => f.Id == id);
			}
			else
			{
				_notyf.Error("There`s no car with the Id: " + id, 20);
				_notyf.Error("Please go back to List!");
			}
		}
	}
}
