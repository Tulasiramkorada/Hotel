namespace hotel.Models;
using hotel.DTOs;

public record Guests
{
    public long GuestId { get; set; }
    public String GuestName { get; set; }
    public String GuestDetails { get; set; }

    public GuestDTO asDTO => new GuestDTO
    {
        GuestId = GuestId,
        GuestName = GuestName,
        GuestDetails = GuestDetails,

    };
}

