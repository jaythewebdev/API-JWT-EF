using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models.DTO
{
    public class IdDTO
    {
        [Required]
        public int Id {get; set; }
    }
}
