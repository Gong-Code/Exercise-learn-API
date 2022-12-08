using learnApi.Models.CarDtos;
using learnApi.Models.FuelDtos;

namespace learnApi.Data.Entities
{
    public class CarEntity
    {
        public List<Car> Cars { get; set; } = new List<Car>();
       
        public static CarEntity AllCars { get; } = new CarEntity();

        public CarEntity()
        {
            //dummy data
            Cars = new List<Car>()
            {
               new Car()
               {
                   Id = 1,
                   Brand = "Volvo",
                   Engine = "Combustion Engine",
                   Fuels = new List<Fuel>
                   {
                       new Fuel()
                       {
                           Id = 1,
                           FuelType = "Gas",
                           Description = "A gasoline car typically uses a spark-ignited internal combustion engine."
                       }
                   }
                   
               },
               new Car()
               {
                   Id = 2,
                   Brand = "Tesla",
                   Engine = "Electric Engine",
                   Fuels = new List<Fuel>
                   {
                       new Fuel()
                       {
                           Id = 2,
                           FuelType = "Electric",
                           Description = "Electric vehicles (EVs) have a battery instead of a gasoline tank, and an electric motor instead of an internal combustion engine."
                       }
                   }
               },
               new Car()
               {
                   Id = 3,
                   Brand = "Toyota",
                   Engine = "Hybrid Engine",
                   Fuels = new List<Fuel>
                   {
                        new Fuel()
                        {
                           Id = 3,
                           FuelType = "Hybrid",
                           Description = "Hybrid electric vehicles are powered by an internal combustion engine and one or more electric motors, which uses energy stored in batteries."
                        }
                   }
               }
            };
        }
    }
}
