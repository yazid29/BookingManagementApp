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
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
            return new Room
            {
                Guid = new Guid(),
                Name = CreateDto.Name,
                Floor = CreateDto.Floor,
                Capacity = CreateDto.Capacity,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
