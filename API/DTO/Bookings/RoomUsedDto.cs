namespace API.DTO.Bookings
{
    public class RoomUsedDto
    {
        public Guid BookingGuid { get; set; }
        public string RoomName { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public string BookedBy { get; set; }

    }
}
