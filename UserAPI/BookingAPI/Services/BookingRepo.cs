using BookingAPI.Exceptions.CustomExceptions;
using BookingAPI.Interfaces;
using BookingAPI.Models;
using BookingAPI.Models.DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace BookingAPI.Services
{
    public class BookingRepo : IBaseCRUD<IdDTO, Booking>
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context)
        {
            _context = context;
        }
        public Booking Add(Booking item)
        {
            try
            {
                var booking=_context.Bookings.Add(item);
                if(booking != null)
                {
                    _context.SaveChanges();
                    return item;
                }
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public Booking Delete(IdDTO item)
        {
            try
            {
                var bookings = _context.Bookings.ToList();
                var myBookings = bookings.FirstOrDefault(r => r.BookingID == item.Id);
                if (myBookings != null)
                {
                    _context.Bookings.Remove(myBookings);
                    _context.SaveChanges();
                    return myBookings;
                }
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public Booking Get(IdDTO item)
        {
            try
            {
                var booking = _context.Bookings.ToList();
                var myBookings = booking.FirstOrDefault(r => r.BookingID == item.Id);
                if (myBookings != null)
                    return myBookings;
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }

        }

        public ICollection<Booking> GetAll()
        {
            try
            {
                var myBookings = _context.Bookings.ToList();
                if (myBookings != null)
                    return myBookings;
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public Booking Update(Booking item)
        {
            try
            {
                var booking = _context.Bookings.ToList();
                var myBookings = booking.FirstOrDefault(r => r.BookingID == item.BookingID);
                if (myBookings != null)
                {
                    myBookings.BookingID = item.BookingID != 0 ? item.BookingID : myBookings.BookingID;
                    myBookings.RoomID = item.RoomID != 0 ? item.RoomID : myBookings.RoomID;
                    myBookings.HotelID = item.HotelID != 0 ? item.HotelID : myBookings.HotelID;
                    myBookings.BookingID = item.BookingID != 0 ? item.BookingID : myBookings.BookingID;
                    myBookings.CheckInDate = item.CheckInDate != default(DateTime) ? item.CheckInDate : myBookings.CheckInDate;
                    myBookings.CheckOutDate = item.CheckOutDate != default(DateTime) ? item.CheckOutDate : myBookings.CheckOutDate;
                    _context.Bookings.Update(myBookings);
                    _context.SaveChanges();
                    return myBookings;
                }
                return null;
            }
            catch (NullReferenceException nre)
            {
                throw new InvalidNullReferenceException(nre.Message);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidArgumentNullException(ane.Message);
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }
    }
}
