using HotelAPI.Exceptions.CustomExceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class HotelRepo : IBaseCRUD<IdDTO,Hotel>
    {
        private readonly HotelContext _context;

        public HotelRepo(HotelContext context)
        {
            _context = context;
        }
        public Hotel Add(Hotel item)
        {
            try
            {
                var hotel=_context.Hotels.Add(item);
                if(hotel!= null)
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

        public Hotel Delete(IdDTO idDto)
        {
            try
            {
                var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == idDto.Id);
                if(hotel!= null)
                {
                    _context.Hotels.Remove(hotel);
                    _context.SaveChanges();
                    return hotel;
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

        public Hotel Get(IdDTO idDto)
        {
            try
            {
                var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == idDto.Id);
                if (hotel == null)
                {
                    return null;
                }
                return hotel;
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

        public ICollection<Hotel> GetAll()
        {
            try
            {
                var hotel = _context.Hotels.ToList();
                if (hotel != null)
                    return hotel;
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

        public Hotel Update(Hotel item)
        {
            try
            {
                var hotel = _context.Hotels.FirstOrDefault(u => u.HotelId == item.HotelId); 
                if (hotel != null)
                {
                    hotel.HotelBranch = item.HotelBranch!=null?item.HotelBranch:hotel.HotelBranch;
                    hotel.HotelPhoneNumber = item.HotelPhoneNumber!=null?item.HotelPhoneNumber:hotel.HotelPhoneNumber;
                    hotel.HotelLocation = item.HotelLocation != null ? item.HotelLocation : hotel.HotelLocation;
                    _context.Hotels.Update(hotel);
                    _context.SaveChanges();
                    return hotel;
                }
                else
                {
                    return null;
                }
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
