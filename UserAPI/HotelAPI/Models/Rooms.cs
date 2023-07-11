using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotels { get; set; }

        [Range(500, 100000, ErrorMessage = "Enter a price between 500-100000")]
        public int Price { get; set; }

        [MaxLength(6, ErrorMessage = "Type Should be either AC or NON-AC")]
        public String? Type { get; set; }

        [Range(1, 20, ErrorMessage = "Enter a valid Persons between 1-20")]
        public int Sharing { get; set; }
    }
}
