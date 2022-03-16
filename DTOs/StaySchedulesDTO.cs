using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record StayScheduleDTO
{
    [JsonPropertyName("stayschedule_id")]
    public long StayScheduleId { get; set; }
    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }
    [JsonPropertyName("guest_id")]
    public long GuestId { get; set; }
    [JsonPropertyName("check_in")]
    public DateTimeOffset CheckIn { get; set; }
    [JsonPropertyName("check_out")]
    public DateTimeOffset CheckOut { get; set; }

}
public record StayScheduleCreateDTO
{
    [JsonPropertyName("stayschedule_id")]


    public long StayScheduleId { get; set; }

    [JsonPropertyName("room_id")]


    public long RoomId { get; set; }

    [JsonPropertyName("guest_id")]

    public long GuestId { get; set; }
    [JsonPropertyName("check_in")]

    public DateTimeOffset CheckIn { get; set; }
    [JsonPropertyName("check_out")]

    public DateTimeOffset CheckOut { get; set; }



}

