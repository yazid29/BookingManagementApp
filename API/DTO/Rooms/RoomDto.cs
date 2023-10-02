using BookingManagementApp.Models;

namespace API.DTO.Rooms
{
    public class RoomDto : GeneralGuid
    {
        // atribut yang ingin ditampilkan ke User
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        public static explicit operator RoomDto(Room room)
        {
            // atribut yang ingin ditampilkan dan diisi oleh User
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
            // konversi DTO ke Model University agar dapat diproses oleh Repository-Model
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
