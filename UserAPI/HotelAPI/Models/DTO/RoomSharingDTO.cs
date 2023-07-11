using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class RoomSharingDTO
    {
        public int ID { get; set; }

        [Range(1, 20, ErrorMessage = "Enter a valid Persons between 1-20")]
        public int sharing { get; set; }
    }
}
