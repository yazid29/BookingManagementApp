using API.DTO.Universities;
using BookingManagementApp.Models;

namespace API.DTO.Rooms
{
    public class RoomDto : GeneralGuid
    {
        //public System.Guid Guid { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        public static explicit operator RoomDto(Room room)
        {
            return new RoomDto
            {
                Guid = room.Guid,
                Name = room.Name,
                Floor = room.Floor,
                Capacity = room.Capacity,
            };
        }

        public static implicit operator Room(RoomDto roomDto)
        {
            return new Room
            {
                Guid = roomDto.Guid,
                Name = roomDto.Name,
                Floor = roomDto.Floor,
                Capacity = roomDto.Capacity,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
