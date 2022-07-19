namespace WebApplicationRazor
{
    public static class ConstantCar
    {
        private static List<Models.Car> baseCars = new()
        {
            new Models.Car { Id=1, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=2, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=3, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=4, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
            new Models.Car { Id=5, Make="Audi", Model="R8", Year=2018, Doors=2, Color="Red", Price=79995},
        };

        private static List<Models.Car> toUpdateCars = baseCars;

        public static List<Models.Car> cars => toUpdateCars ?? baseCars;

        public static void ResetBaseCars()
        {
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
