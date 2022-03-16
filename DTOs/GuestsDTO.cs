using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record GuestDTO
{
    [JsonPropertyName("guest_id")]
    public long GuestId { get; set; }
    [JsonPropertyName("guest_name")]
    public String GuestName { get; set; }
    [JsonPropertyName("guest_details")]
    public String GuestDetails { get; set; }

    [JsonPropertyName("stay_schedule")]
    public List<StayScheduleDTO> StaySchedule { get; internal set; }

}
public record GuestCreateDTO
{
    [JsonPropertyName("guest_id")]
    [Required]

    public long GuestId { get; set; }

    [JsonPropertyName("guest_name")]
    [Required]

    public String GuestName { get; set; }

    [JsonPropertyName("guest_details")]
    [Required]
    public String GuestDetails { get; set; }

}
public record GuestUpdateDTO
{
    [JsonPropertyName("guest_name")]

    public String GuestName { get; set; }

    [JsonPropertyName("guest_details")]
    public String GuestDetails { get; set; }

}