using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTO;

namespace BookingAPI.Services
{
    public class BookingServices
    {
        private readonly IBaseCRUD<IdDTO,Booking> _bookingRepo;

        public BookingServices(IBaseCRUD<IdDTO, Booking> bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

            public Booking BookHotel(Booking booking)
            {
                // Validate if the same hotel has an existing reservation with overlapping dates
                if (IsHotelAvailable(booking.HotelID, booking.RoomID, booking.CheckInDate, booking.CheckOutDate))
                {
                    var myBooking=_bookingRepo.Add(booking);
                    if(myBooking != null)
                    {
                        return myBooking;
                    }
                        return null;
                }
                return null;
            }

            public Booking CancelReservation(IdDTO bookingID)
            {
                var bookings=_bookingRepo.Delete(bookingID);
            
                if (bookings != null)
                {
                return bookings;
                }
                return null;
            }

        public Booking GetByID(IdDTO idDTO)
        {
            var booking = _bookingRepo.Get(idDTO);
            if (booking != null)
                return booking;
            return null;
        }

        public Booking Update(Booking booking)
        {
            var bookings = new Booking();
            bookings.HotelID = booking.HotelID;
            bookings.RoomID = booking.RoomID;
            bookings.HotelBranch = booking.HotelBranch;
            bookings.BookingID = booking.BookingID;
            bookings.CheckInDate = booking.CheckInDate;
            bookings.CheckOutDate = booking.CheckOutDate;
            var myBooking = _bookingRepo.Update(bookings);
            if (myBooking != null)
                return booking;
            return null;
        }

        public List<Booking> GetAll()
        {
            var booking = _bookingRepo.GetAll().ToList();
            if (booking != null)
                return booking;
            return null;
        }
        public List<Booking> BookedRoomsByHotel(IdDTO idDTO)
        {
            var booking = _bookingRepo.GetAll().ToList();
            var mybookedRooms = booking.Where(R => R.HotelID == idDTO.Id).ToList();
            if (mybookedRooms != null)
                return mybookedRooms;
            return null;
        }


        private bool IsHotelAvailable(int HotelID,int RoomID, DateTime checkInDate, DateTime checkOutDate)
            {
                var myBookings=_bookingRepo.GetAll().ToList();
                foreach(var booking in myBookings) 
                {
                    if (booking.HotelID.Equals(HotelID) && booking.RoomID.Equals(RoomID) &&
                        (checkInDate >= booking.CheckInDate && checkInDate <= booking.CheckOutDate ||
                         checkOutDate >= booking.CheckInDate && checkOutDate <= booking.CheckOutDate))
                    {
                        return false;
                    }
                }
                return true;
            }
    }
}
