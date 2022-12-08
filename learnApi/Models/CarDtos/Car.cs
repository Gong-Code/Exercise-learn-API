using learnApi.Models.FuelDtos;

namespace learnApi.Models.CarDtos
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Engine { get; set; } = null!;

        public ICollection<Fuel> Fuels { get; set; } = new List<Fuel>();

    }
}
