using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class RoomTypeDTO
    {
        public int Id { get; set; }

        [MaxLength(6, ErrorMessage = "Type Should be either AC or NON-AC")]
        public String RoomType { get; set; }
    }
}
