using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Services
{
    public class HotelServices
    {
        private readonly IBaseCRUD<IdDTO, Hotel> _hotelRepo;
        private readonly IBaseCRUD<IdDTO, Rooms> _roomRepo;

        public HotelServices(IBaseCRUD<IdDTO, Hotel> hotelRepo, IBaseCRUD<IdDTO, Rooms> roomRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
        }


     //Hotel crud operation

    public Hotel AddHotel(Hotel hotel)
    {
        var hotels = _hotelRepo.Add(hotel);
        if (hotels != null)
        {
            return hotels;
        }
        return null;
    }
        public List<Hotel> GetAllHotels()
        {
            var hotels = _hotelRepo.GetAll().ToList();
            if (hotels.Count > 0)
                return hotels;
            return null;
        }

        public Hotel GetHotelById(IdDTO hotelId)
        {
            var hotels = _hotelRepo.Get(hotelId);
            if (hotels != null)
                return hotels;
            return null;
        }

        public Hotel DeleteHotel(IdDTO hotelId)
        {
            var hotels = _hotelRepo.Delete(hotelId);
            if (hotels != null)
                return hotels;
            return null;
        }

        public Hotel Update(Hotel hotel)
        {
            var myHotel = _hotelRepo.Update(hotel);
            if (myHotel != null)
                return myHotel;
            return null;
        }


        //Room Functionalities 
        public Rooms AddRoom(Rooms room)
        {
        var hotels = _hotelRepo.GetAll();
        var hotel = hotels.FirstOrDefault(h => h.HotelId == room.HotelId);
        var rooms = _roomRepo.Add(room);
        if (rooms != null && hotel != null)
            return rooms;
        return null;
        }

        public List<Rooms> GetAllRooms()
        {
            var rooms = _roomRepo.GetAll().ToList();
            if (rooms.Count > 0)
                return rooms;
            return null;
        }


        //Available rooms Count from each hotel
        public CountDTO RoomCount(IdDTO hotelId)
        {
            var rooms= _roomRepo.GetAll().ToList();
            CountDTO countDTO = new CountDTO();
            countDTO.Count=rooms.Where(h => h.HotelId == hotelId.Id).Count();
            return  countDTO;
        }

        //Filter by location
        public List<Hotel>? FilterHotelByLocation(LocationSearchDTO locationDTO)
        {
            var hotels = _hotelRepo.GetAll().ToList();
            var myHotels = hotels.Where(h => h.HotelLocation == locationDTO.Location).ToList();
            if (myHotels!=null)
                return myHotels;
            return null;
        }

        //Search by Hotel branch
        public List<Rooms>? SearchRoomsByHotelBranch(BranchSearchDTO branchDTO)
        {
            var hotels= _hotelRepo.GetAll().ToList();
            var rooms = _roomRepo.GetAll().ToList();
            var myHotel = hotels.FirstOrDefault(h => h.HotelBranch == branchDTO.Branch);
            List<Rooms>? myRooms =null;
            if (myHotel != null)
            {
                myRooms = rooms.Where(r => r.HotelId == myHotel.HotelId).ToList();
            }
            if (myRooms != null)
                return myRooms;
            return null;
        }

        //Filter rooms by hotel ID
        public List<Rooms> GetRoomByHotelID(IdDTO hotelId)
        {
            var rooms = _roomRepo.GetAll().ToList();
            var myRooms = rooms.Where(h => h.HotelId == hotelId.Id).ToList();
            if (myRooms != null)
            {
                return myRooms;
            }
            return null;
        }

        //Filter Room by type
        public List<Rooms> FilterRoomByType(RoomTypeDTO typeDTO)
        {
            var rooms = _roomRepo.GetAll().ToList();
            var myRooms = rooms.Where(h => h.HotelId == typeDTO.Id && h.Type==typeDTO.RoomType).ToList();
            if (myRooms.Count > 0)
                return myRooms;
            return null;
        }

        //Filter Room by sharing
        public List<Rooms> FilterRoomBySharing(RoomSharingDTO roomSharing)
        {
            var rooms = _roomRepo.GetAll().ToList();
            var myRooms = rooms.Where(h => h.HotelId == roomSharing.ID && h.Sharing == roomSharing.sharing).ToList();
            if (myRooms.Count > 0)
                return myRooms;
            return null;
        }


        //Sort By Price Range without Hotel ID
        public List<PriceFilteredDataDTO> FilterRoomByPriceWithoutID(PriceRangeDTO priceRange)
        {
            var rooms = _roomRepo.GetAll().ToList();             
            PriceFilteredDataDTO priceFilteredData = null;
            List<PriceFilteredDataDTO> priceFilteredDatas = new List<PriceFilteredDataDTO>();
            if (rooms.Count > 0)
            {
                    foreach (var room in rooms)
                    {
                        IdDTO idDTO=new IdDTO();
                        idDTO.Id = room.HotelId;
                        var myHotel = _hotelRepo.Get(idDTO);
                        priceFilteredData = new PriceFilteredDataDTO();
                        priceFilteredData.HotelId = myHotel.HotelId;
                        priceFilteredData.HotelBranch = myHotel.HotelBranch;
                        priceFilteredData.HotelPhoneNumber = myHotel.HotelPhoneNumber;
                        priceFilteredData.HotelLocation = myHotel.HotelLocation;
                        priceFilteredData.HotelRating = myHotel.HotelRating;

                        priceFilteredData.RoomId = room.RoomId;
                        priceFilteredData.Price = room.Price;
                        priceFilteredData.Type = room.Type;
                        priceFilteredData.Sharing = room.Sharing;

                        priceFilteredDatas.Add(priceFilteredData);
                    }
                }
            else
                return null;

            if (priceFilteredDatas.Count > 0)
                return priceFilteredDatas;
            return null;
        }

    }
}
