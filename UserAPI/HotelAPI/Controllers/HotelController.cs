using HotelAPI.Exceptions.CustomExceptions;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using HotelAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelServices _hotelServices;

        public HotelController(HotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Add Hotel")]
        [Authorize(Roles="Staff")]
        [Authorize]
        public ActionResult<Hotel> AddHotel(Hotel hotel)
        {
            try
            {
                Hotel newHotel = _hotelServices.AddHotel(hotel);
                if (newHotel == null)
                    return BadRequest(new Error(1,"Unable to add Hotel"));
                return Created("Hotel Added Successfully", newHotel);
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("View Available Hotels")]
        public ActionResult<List<Hotel>> GetAllHotel()
        {
            try
            {
                var hotels = _hotelServices.GetAllHotels();
                if (hotels != null)
                    return Ok(hotels);
                return NotFound(new Error(1,"No Hotels available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }


        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("View Hotel by HotelID")]
        public ActionResult<Hotel> GetHotelByID(IdDTO idDTO)
        {
            try
            {
                var hotel = _hotelServices.GetHotelById(idDTO);
                if (hotel != null)
                    return Ok(hotel);
                return NotFound(new Error(1,"No Hotel available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }


        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete("Delete Hotel by HotelID")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Hotel> DelteHotelByID(IdDTO idDTO)
        {
            try
            {
                var hotel = _hotelServices.DeleteHotel(idDTO);
                if (hotel != null)
                    return Ok(hotel);
                return NotFound(new Error(1,"No Hotel available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut("Update Hotel by HotelID")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Hotel> UpdateHotel(Hotel hotel)
        {
            try
            {
                var myhotel = _hotelServices.Update(hotel);
                if (myhotel != null)
                    return Ok(myhotel);
                return NotFound(new Error(1,"Hotel Not updated"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Add Rooms")]
        [Authorize(Roles = "Staff")]
        [Authorize]
        public ActionResult<Rooms> AddRoom(Rooms room)
        {
            try
            {
                var myroom = _hotelServices.AddRoom(room);
                if (myroom != null)
                    return Created("Room created Successfully", myroom);
                return BadRequest("Unable to add Room");
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("View All Available Rooms")]
        public ActionResult<List<Rooms>> GetAllRooms()
        {
            try
            {
                var myroom = _hotelServices.GetAllRooms();
                if (myroom != null)
                    return Ok(myroom);
                return BadRequest(new Error(1,"Unable to add Room"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("View Rooms By Hotel ID")]
        public ActionResult<List<Rooms>> ViewRoomsByHotelID(IdDTO idDTO)
        {
            try
            {
                var rooms = _hotelServices.GetRoomByHotelID(idDTO);
                if (rooms != null)
                {
                    return Ok(rooms);

                }
                return NotFound(new Error(1,"No available rooms"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Search Hotel by Location")]
        public ActionResult<List<Hotel>> SearchHotelByLocation(LocationSearchDTO locationDTO)
        {
            try
            {
                var hotels = _hotelServices.FilterHotelByLocation(locationDTO);
                if (hotels != null)
                    return Ok(hotels);
                return NotFound(new Error(1, "No Hotels available in this location"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Search Hotel by Branch")]
        public ActionResult<List<Rooms>> GetRoomsByHotelBranch(BranchSearchDTO branchDTO)
        {
            try
            {
                var rooms = _hotelServices.SearchRoomsByHotelBranch(branchDTO);
                if (rooms != null)
                    return Ok(rooms);
                return NotFound(new Error(1, "No Rooms available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }

        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Type")]
        public ActionResult<List<Rooms>> FilterRoomsByType(RoomTypeDTO roomType)
        {
            try
            {
                var rooms = _hotelServices.FilterRoomByType(roomType);
                if (rooms != null)
                    return Ok(rooms);
                return NotFound(new Error(1, "No Rooms available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }

        }

        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Sharing")]
        public ActionResult<List<Rooms>> FilterRoomsBySharing(RoomSharingDTO roomSharing)
        {
            try
            {
                var rooms = _hotelServices.FilterRoomBySharing(roomSharing);
                if (rooms != null)
                    return Ok(rooms);
                return NotFound(new Error(1, "No Rooms available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }



        [ProducesResponseType(typeof(PriceFilteredDataDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Filter Rooms by Price")]
        public ActionResult<List<PriceFilteredDataDTO>> FilterRoomsByPriceWithoutID(PriceRangeDTO priceRange)
        {
            try
            {
                var rooms = _hotelServices.FilterRoomByPriceWithoutID(priceRange);
                if (rooms != null)
                    return Ok(rooms);
                return NotFound(new Error(1, "No Rooms available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }


        [ProducesResponseType(typeof(Rooms), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Available Rooms Count")]
        public ActionResult<CountDTO> GetAvailableRoomsCount(IdDTO idDTO)
        {
            try
            {
                CountDTO countDTO=new CountDTO();
                countDTO= _hotelServices.RoomCount(idDTO);
                if (countDTO.Count >= 0)
                    return Ok(countDTO);
                return NotFound(new Error(1, "No Rooms available"));
            }
            catch (InvalidArgumentNullException iane)
            {
                return BadRequest(new Error(2, iane.Message));
            }
            catch (InvalidNullReferenceException inre)
            {
                return BadRequest(new Error(3, inre.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(4, ex.Message));
            }
        }
    }
}
