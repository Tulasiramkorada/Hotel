using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace hotel.DTOs;

public record RoomServiceStaffDTO
{

    [JsonPropertyName("staff_id")]
    public long StaffId { get; set; }
    [JsonPropertyName("staff_name")]
    public String StaffName { get; set; }
    [JsonPropertyName("staff_address")]
    public String StaffAddress { get; set; }
    [JsonPropertyName("contact_number")]
    public long ContactNumber { get; set; }




    public record RoomServiceStaffCreateDTO
    {
        [JsonPropertyName("staff_id")]
        [Required]

        public long StaffId { get; set; }

        [JsonPropertyName("staff_name")]
        [Required]

        public String StaffName { get; set; }

        [JsonPropertyName("staff_address")]
        [Required]
        public String StaffAddress { get; set; }

        [JsonPropertyName("contact_number")]
        [Required]
        public long ContactNumber { get; set; }



    }

    public record RoomServiceStaffUpdateDTO
    {
        [JsonPropertyName("staff_name")]

        public string StaffName { get; set; }

        [JsonPropertyName("staff_address")]
        public string StaffAddress { get; set; }

    }
}