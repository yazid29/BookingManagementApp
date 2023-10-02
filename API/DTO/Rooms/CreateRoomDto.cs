using API.DTO.Universities;
using BookingManagementApp.Models;

namespace API.DTO.Rooms
{
    public class CreateRoomDto
    {
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }

        public static implicit operator Room(CreateRoomDto CreateDto)
        {
            return new Room
            {
                Name = CreateDto.Name,
                Floor = CreateDto.Floor,
                Capacity = CreateDto.Capacity,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
