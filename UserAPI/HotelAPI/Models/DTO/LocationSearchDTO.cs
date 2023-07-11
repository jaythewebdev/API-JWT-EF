using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class LocationSearchDTO
    {
        [MinLength(2, ErrorMessage = "Location should be minimum of 2 characters")]
        public String Location { get; set; }
    }
}
