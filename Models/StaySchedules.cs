using hotel.DTOs;

namespace hotel.Models;

public record StaySchedules
{
    public long StayScheduleId { get; set; }
    public long RoomId { get; set; }
    public long GuestId { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut { get; set; }

    public StayScheduleDTO asDTO => new StayScheduleDTO
    {
        StayScheduleId = StayScheduleId,
        RoomId = RoomId,
        GuestId = GuestId,
        CheckIn = CheckIn,
        CheckOut = CheckOut,
    };
}