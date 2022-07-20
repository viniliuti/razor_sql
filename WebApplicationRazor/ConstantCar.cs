namespace WebApplicationRazor
{
	public static class ConstantCar
	{
		private static List<Models.Car> baseCars = new()
		{
			new Models.Car
			{
				Id = 1,
				Make = "Audi",
				Model = "R8",
				Year = 2018,
				Doors = 2,
				Color = "Red",
				Price = 79995
			},
			new Models.Car
			{
				Id = 2,
				Make = "Tesla",
				Model = "3",
				Year = 2018,
				Doors = 4,
				Color = "Black",
				Price = 54995
			},
			new Models.Car
			{
				Id = 3,
				Make = "Porsche",
				Model = " 911 991",
				Year = 2020,
				Doors = 2,
				Color = "White",
				Price = 155000
			},
			new Models.Car
			{
				Id = 4,
				Make = "Mercedes-Benz",
				Model = "GLE 63S",
				Year = 2021,
				Doors = 5,
				Color = "Blue",
				Price = 83995,
				ShowPrice = true
			},
			new Models.Car
			{
				Id = 5,
				Make = "BMW",
				Model = "X6 M",
				Year = 2020,
				Doors = 5,
				Color = "Silver",
				Price = 62995
			},
		};

		private static List<Models.Car>? toUpdateCars { get; set; }

		public static List<Models.Car> cars => toUpdateCars ?? baseCars;

		static ConstantCar()
		{
			toUpdateCars = new List<Models.Car>();
			baseCars.ForEach((item) =>
			{
				toUpdateCars.Add(new Models.Car()
				{
					Id = item.Id,
					Make = item.Make,
					Model = item.Model,
					Year = item.Year,
					Doors = item.Doors,
					Color = item.Color,
					Price = item.Price,
					ShowPrice = item.ShowPrice
				});
			});
		}

		public static void ResetBaseCars()
		{
			toUpdateCars = new List<Models.Car>();
			baseCars.ForEach((item) =>
			{
				toUpdateCars.Add(new Models.Car()
				{
					Id = item.Id,
					Make = item.Make,
					Model = item.Model,
					Year = item.Year,
					Doors = item.Doors,
					Color = item.Color,
					Price = item.Price,
					ShowPrice = item.ShowPrice
				});
			});
		}

		public static void UpdateCar(int id, Models.Car updatedCar)
		{
			var currentCar = toUpdateCars!
				.Where(w => w.Id == id).FirstOrDefault();

			if (currentCar == null)
				return;

			currentCar.Make = updatedCar.Make;
			currentCar.Model = updatedCar.Model;
			currentCar.Year = updatedCar.Year;
			currentCar.Doors = updatedCar.Doors;
			currentCar.Color = updatedCar.Color;
			currentCar.Price = updatedCar.Price;
			currentCar.ShowPrice = updatedCar.ShowPrice;
		}

		public static void DeleteCar(int id)
		{
			var toRemoveCar = toUpdateCars!
				.Where(w => w.Id == id).FirstOrDefault();

			if (toRemoveCar == null)
				return;

			toUpdateCars!
				.Remove(toRemoveCar);
		}
		public static void AddCar(Models.Car newCar)
		{
			toUpdateCars!.Add(newCar);
		}

	}
}
