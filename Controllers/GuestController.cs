using Microsoft.AspNetCore.Mvc;
using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;
using Hotel.Repositories;

namespace hotel.Controllers;
[ApiController]
[Route("api/guest")]

public class GuestController : ControllerBase
{
    private readonly ILogger<GuestController> _logger;
    private readonly IGuestsRepository _guest;
    private readonly IStayScheduleRepository _stayschedule;

    public GuestController(ILogger<GuestController> logger, IGuestsRepository guest, IStayScheduleRepository stayschedule)
    {
        _logger = logger;
        _guest = guest;
        _stayschedule = stayschedule;
    }
    [HttpGet]
    public async Task<ActionResult<List<GuestDTO>>> GetAllUser()
    {
        var usersList = await _guest.GetList();


        var dtoList = usersList.Select(x => x.asDTO);

        return Ok(dtoList);
    }
    [HttpGet("{guest_id}")]

    public async Task<ActionResult<GuestDTO>> GetUserById([FromRoute] int guest_id)
    {

        var guest = await _guest.GetById(guest_id);

        if (guest is null)
            return NotFound("No Guest found with given guest_id");


        var dto = guest.asDTO;
        dto.StaySchedule = await _stayschedule.GetAllForGuest(guest.GuestId);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<GuestDTO>> CreateGuest([FromBody] GuestCreateDTO Data)
    {
        var ToCreateGuest = new Guests
        {
            GuestId = Data.GuestId,
            GuestName = Data.GuestName,
            GuestDetails = Data.GuestDetails
        };
        var CreatedGuest = await _guest.Create(ToCreateGuest);

        return StatusCode(StatusCodes.Status201Created, CreatedGuest.asDTO);
    }
    [HttpPut("{guest_id}")]

    public async Task<ActionResult> UpdateGuest([FromRoute] int guest_id,
    [FromBody] GuestUpdateDTO Data)
    {
        var existing = await _guest.GetById(guest_id);
        if (existing is null)
            return NotFound("No Guest found with given Guest_Id");

        var toUpdateGuest = existing with
        {
            GuestName = Data.GuestName,
            GuestDetails = Data.GuestDetails

        };

        var didUpdate = await _guest.Update(toUpdateGuest);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update guest");

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteGuest([FromRoute] int guest_id)
    {
        var existing = await _guest.GetById(guest_id);
        if (existing is null)
            return NotFound("No user found with given guest_id");

        var didDelete = await _guest.Delete(guest_id);

        return NoContent();
    }
}