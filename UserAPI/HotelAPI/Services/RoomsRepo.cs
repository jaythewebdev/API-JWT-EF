using HotelAPI.Exceptions.CustomExceptions;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace HotelAPI.Services
{
    public class RoomsRepo : IBaseCRUD<IdDTO, Rooms>
    {
        private readonly HotelContext _context;

        public RoomsRepo(HotelContext context)
        {
            _context = context;
        }
        public Rooms Add(Rooms item)
        {
            try
            {
                var room=_context.Room.Add(item);
                if(room != null)
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

        public Rooms Delete(IdDTO idDTO)
        {
            try
            {
                var room = _context.Room.FirstOrDefault(u => u.RoomId == idDTO.Id);
                if(room != null)
                {
                    _context.Room.Remove(room);
                    _context.SaveChanges();
                    return room;
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

        public Rooms Get(IdDTO idDTO)
        {
            try
            {
                var room = _context.Room.FirstOrDefault(u => u.RoomId == idDTO.Id);
                if (room == null)
                {
                    return null;
                }
                return room;
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

        public ICollection<Rooms> GetAll()
        {
            try
            {
                var rooms = _context.Room.ToList();
                if (rooms != null)
                    return rooms;
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

        public Rooms Update(Rooms item)
        {
            try
            {
                var room = _context.Room.FirstOrDefault(u => u.RoomId == item.RoomId);
                if (room != null)
                {
                    room.Price = item.Price;
                    room.Type = item.Type;
                    room.Sharing = item.Sharing;
                    _context.Room.Update(room);
                    _context.SaveChanges();
                    return room;
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
