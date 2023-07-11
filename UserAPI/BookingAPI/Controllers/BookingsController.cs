using BookingAPI.Exceptions.CustomExceptions;
using BookingAPI.Models;
using BookingAPI.Models.DTO;
using BookingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingServices _bookingServices;

        public BookingsController(BookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Book A Room")]
        [Authorize]
        public ActionResult<Booking> BookARoom(Booking booking)
        {
            try
            {
                var myReservation = _bookingServices.BookHotel(booking);
                if (myReservation != null)
                    return Created("Room Booked Successfully", myReservation);
                return BadRequest(new Error(1,"Unable to Book Room as the date and room being already booked"));
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


        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpDelete("Booking Cancellation")]
        [Authorize]
        public ActionResult<Booking> CancelABooking(IdDTO idDTO)
        {
            try
            {
                var reservation = _bookingServices.CancelReservation(idDTO);
                if (reservation != null)
                    return Ok(reservation);
                return BadRequest(new Error(1, $"There is No Bookings for the id: {idDTO.Id}"));
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

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Search Booking by Booking ID")]
        [Authorize]
        public ActionResult<Booking> GetBookingById(IdDTO idDTO)
        {
            try
            {
                var reservation = _bookingServices.GetByID(idDTO);
                if (reservation != null)
                    return Ok(reservation);
                return NotFound(new Error(1, $"There is No Bookings for the id: {idDTO.Id}"));
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

        [ProducesResponseType(typeof(List<Booking>), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpGet("View All Bookings")]
        [Authorize]
        public ActionResult<Booking> GetAllBookings()
        {
            try
            {
                var reservations = _bookingServices.GetAll();
                if (reservations != null)
                    return Ok(reservations);
                return NotFound(new Error(1,"No Bookings Available"));
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

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("Update Booking")]
        [Authorize]
        public ActionResult<Booking> UpdateABooking(Booking booking)
        {
            try
            {
                var newReservation = _bookingServices.Update(booking);
                if (newReservation != null)
                    return Ok(newReservation);
                return BadRequest(new Error(1, $"There is No Bookings for the id: {booking.BookingID}"));
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

        [ProducesResponseType(typeof(Booking), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost("View Bookings BY Hotel")]
        [Authorize]
        public ActionResult<Booking> ViewBookingByHotelID(IdDTO idDTO)
        {
            try
            {
                var newReservation = _bookingServices.BookedRoomsByHotel(idDTO);
                if (newReservation != null)
                    return Ok(newReservation);
                return BadRequest($"There is No Bookings for the id: {idDTO.Id}");
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
