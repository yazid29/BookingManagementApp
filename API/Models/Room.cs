using System;
namespace BookingManagementApp.Models
{
    [Table("tb_m_rooms")]
    public class Room : GeneralAtribute
    {
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column("floor")]
        public int Floor { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
    }
}