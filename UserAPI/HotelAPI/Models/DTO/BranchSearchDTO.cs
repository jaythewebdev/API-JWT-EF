using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models.DTO
{
    public class BranchSearchDTO
    {

        [MinLength(6, ErrorMessage = "Hotel Branch should be minimum of 6 characters")]
        public String Branch { get; set; }
    }
}
