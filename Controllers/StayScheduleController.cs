using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace hotel.Controllers;


[ApiController]
[Route("api/stayschedule")]

public class StayScheduleController : ControllerBase
{
    private readonly ILogger<StayScheduleController> _logger;
    private readonly IStayScheduleRepository _stayschedule;

    public StayScheduleController(ILogger<StayScheduleController> logger, IStayScheduleRepository stayschedule)
    {
        _logger = logger;
        _stayschedule = stayschedule;
    }
    [HttpGet]
    public async Task<ActionResult<List<StayScheduleDTO>>> GetAllUsers()
    {
        var usersList = await _stayschedule.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpPost]
    public async Task<ActionResult<StayScheduleDTO>> CreateStaySchedule([FromBody] StayScheduleCreateDTO Data)
    {
        var toCreateStaySchedule = new StaySchedules
        {
            StayScheduleId = Data.StayScheduleId,
            RoomId = Data.RoomId,
            GuestId = Data.GuestId,
            CheckIn = Data.CheckIn,
            CheckOut = Data.CheckOut
        };
        var createdRoom = await _stayschedule.Create(toCreateStaySchedule);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpGet("{stay_schedule_id}")]
    public async Task<ActionResult<StayScheduleDTO>> GetUserById([FromRoute] long stay_schedule_id)
    {
        var user = await _stayschedule.GetById(stay_schedule_id);

        if (user is null)
            return NotFound("No user found with given stay schedule_id");

        return Ok(user.asDTO);
    }
    // [HttpPut("{stay_schedule_id}")]
    // public async Task<ActionResult> UpdateUser([FromRoute] long stay_schedule_id,
    //    [FromBody] StayScheduleUpdateDTO Data)
    // {
    //     var existing = await _stayschedule.GetById(stay_schedule_id);
    //     if (existing is null)
    //         return NotFound("No user found with given room_id");

    //     var toUpdateRoom = existing with
    //     {
    //         Room_Type = Data.Room_Types,
    //         Room_Number = Data.Room_Number

    //     };



    [HttpDelete("{stay_schedule_id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long stay_schedule_id)
    {
        var existing = await _stayschedule.GetById(stay_schedule_id);
        if (existing is null)
            return NotFound("No user found with given stay schedule_id");

        var didDelete = await _stayschedule.Delete(stay_schedule_id);

        return NoContent();
    }
}
