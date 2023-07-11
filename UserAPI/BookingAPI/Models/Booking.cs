using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }


        [Required]
        public int HotelID { get; set; }

        [MinLength(6, ErrorMessage = "Branch Name should be minimum of 6 characters")]
        public string? HotelBranch { get; set; }

        [Required]
        public int RoomID { get; set; }


        [Required]
        [MinLength(2, ErrorMessage = "Customer Name should be minimum of 2 characters")]
        public string? CustomerName { get; set; }


        [Required]
        public DateTime CheckInDate { get; set; }


        [Required]
        public DateTime CheckOutDate { get; set; }



    }
}
