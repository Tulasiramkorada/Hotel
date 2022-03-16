using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record RoomDTO
{
    [JsonPropertyName("room_id")]
    public long RoomId { get; set; }
    [JsonPropertyName("room_type")]
    public long RoomType { get; set; }
    [JsonPropertyName("room_no")]
    public long RoomNo { get; set; }
    [JsonPropertyName("staff_id")]
    public long StaffId { get; set; }
    public List<RoomServiceStaffDTO> RoomServiceStaff { get; internal set; }
}
public record RoomCreateDTO
{
    [JsonPropertyName("room_id")]
    [Required]

    public long RoomId { get; set; }

    [JsonPropertyName("room_type")]
    [Required]

    public long RoomType { get; set; }

    [JsonPropertyName("room_no")]
    [Required]
    public long RoomNo { get; set; }

    [JsonPropertyName("Staff_id")]
    [Required]
    public long StaffId { get; set; }

}
public record RoomUpdateDTO
{
    [JsonPropertyName("room_no")]

    public long RoomNo { get; set; }

    [JsonPropertyName("room_type")]
    public long RoomType { get; set; }



}