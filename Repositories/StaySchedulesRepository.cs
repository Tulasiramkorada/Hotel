using Dapper;
using hotel.DTOs;
using hotel.Models;

namespace hotel.Repositories;

public interface IStayScheduleRepository
{
    Task<StaySchedules> Create(StaySchedules Item);

    Task<bool> Delete(long StayScheduleId);
    Task<StaySchedules> GetById(long StayScheduleId);
    Task<List<StaySchedules>> GetList();
    Task<List<StayScheduleDTO>> GetAllForGuest(long GuestId);


}
public class StaySchedulesRepository : BaseRepository, IStayScheduleRepository
{
    public StaySchedulesRepository(IConfiguration configuration) : base(configuration)
    {
    }
    public async Task<StaySchedules> Create(StaySchedules Item)
    {
        var query = $@"INSERT INTO stayschedule(stayschedule_id, room_id, guest_id, check_in, check_out) VALUES (@StayScheduleId, @RoomId, @GuestId, @CheckIn, @CheckOut) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<StaySchedules>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(long StayScheduleId)
    {
        var query = $@"DELETE FROM stayschedule WHERE stayschedule_id = @StayScheduleId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { StayScheduleId });
            return result > 0;

        }
    }

    public async Task<StaySchedules> GetById(long StayScheduleId)
    {
        var query = $@"SELECT * FROM stayschedule WHERE stayschedule_id = @StayScheduleId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<StaySchedules>(query, new { StayScheduleId });
    }

    public async Task<List<StaySchedules>> GetList()
    {
        var query = $@"SELECT * FROM stayschedule";
        List<StaySchedules> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<StaySchedules>(query)).AsList();
        return result;
    }

    public async Task<List<StayScheduleDTO>> GetAllForGuest(long GuestId)
    {
        var query = $@"SELECT * FROM stayschedule WHERE guest_id = @GuestId";
        using (var con = NewConnection)

            return (await con.QueryAsync<StayScheduleDTO>(query, new { GuestId })).AsList();
    }


}

