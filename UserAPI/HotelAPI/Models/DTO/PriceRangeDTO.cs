using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class PriceRangeDTO
    {
        [Required]
        [Range(500, 100000)]
        public int minPrice { get; set; }

        [Required]
        [Range(600, 100000)]
        public int maxPrice { get; set; } 
    }
}
