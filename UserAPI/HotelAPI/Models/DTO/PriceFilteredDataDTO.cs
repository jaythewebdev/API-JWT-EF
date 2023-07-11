using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class PriceFilteredDataDTO
    {
        public int HotelId { get; set; }

        [MinLength(6, ErrorMessage = "Hotel Branch should be minimum of 6 characters")]
        public string? HotelBranch { get; set; }

        [MinLength(10, ErrorMessage = "Phone Number should be of 10 character")]
        public string? HotelPhoneNumber { get; set; }

        [MinLength(2, ErrorMessage = "Location should be minimum of 2 characters")]
        public string? HotelLocation { get; set; }

        [Range(1, 10, ErrorMessage = "Enter a Rating between 1-10")]
        public int? HotelRating { get; set; }
        public int RoomId { get; set; }

        [Range(500, 100000, ErrorMessage = "Enter a price between 500-100000")]
        public int Price { get; set; }

        [MaxLength(6, ErrorMessage = "Type Should be either AC or NON-AC")]
        public String? Type { get; set; }

        [Range(1, 20, ErrorMessage = "Enter a valid Persons between 1-20")]
        public int Sharing { get; set; }
    }
}
