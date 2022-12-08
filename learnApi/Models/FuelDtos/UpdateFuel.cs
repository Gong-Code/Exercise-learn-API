using System.ComponentModel.DataAnnotations;

namespace learnApi.Models.FuelDtos
{
    public class UpdateFuel
    {
        [Required(ErrorMessage = "You should provide a fuel type.")]
        [MaxLength(50)]
        public string FuelType { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = null!;
    }
}
