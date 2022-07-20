namespace WebApplicationRazor
{
	public static class ConstantCar
	{
		private static List<Models.Car> baseCars = new()
		{
			new Models.Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
			new Models.Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
			new Models.Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
			new Models.Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995, ShowPrice = true },
			new Models.Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
		};

		private static List<Models.Car>? toUpdateCars { get; set; }

		public static List<Models.Car> cars => toUpdateCars ?? baseCars;

		public static void ResetBaseCars()
		{
			System.Console.WriteLine(baseCars[0].ShowPrice);
			System.Console.WriteLine(toUpdateCars[0].ShowPrice);
			toUpdateCars = baseCars;
		}

		public static void UpdateCar(int id, Models.Car updatedCar)
		{
			var currentCar = toUpdateCars
				.Where(w => w.Id == id).FirstOrDefault();

			if (currentCar == null)
				return;

			currentCar = updatedCar;
		}

		public static void DeleteCar(int id)
		{
			var toRemoveCar = toUpdateCars
				.Where(w => w.Id == id).FirstOrDefault();

			if (toRemoveCar == null)
				return;

			toUpdateCars
				.Remove(toRemoveCar);
		}
		public static void AddCar(Models.Car newCar)
			=> toUpdateCars.Add(newCar);

	}
}
