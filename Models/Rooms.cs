using hotel.DTOs;

namespace hotel.Models;

public record Rooms
{
    public long RoomId { get; set; }
    public long RoomType { get; set; }
    public long RoomNo { get; set; }
    public long StaffId { get; set; }
    public RoomDTO asDTO => new RoomDTO
    {
        RoomId = RoomId,
        RoomType = RoomType,
        RoomNo = RoomNo,
        StaffId = StaffId,
    };
}