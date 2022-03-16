using Dapper;
using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;

namespace Hotel.Repositories;

public interface IRoomsRepository
{
    Task<Rooms> Create(Rooms Item);
    Task<bool> Update(Rooms Item);
    Task<bool> Delete(long RoomId);
    Task<Rooms> GetById(long RoomId);
    Task<List<Rooms>> GetList();
    Task<List<RoomServiceStaffDTO>> GetAllForRoom(long RoomId);

}
public class RoomsRepository : BaseRepository, IRoomsRepository
{
    public RoomsRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Rooms> Create(Rooms Item)
    {
        var query = $@"INSERT INTO ""rooms"" (room_id, room_type, room_no, staff_id) 
        VALUES (@RoomId, @RoomType, @RoomNo, @StaffId) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Rooms>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(long RoomId)
    {
        var query = $@"DELETE FROM rooms WHERE room_id=@RoomId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { RoomId });
            return result > 0;

        }
    }

    public async Task<List<RoomServiceStaffDTO>> GetAllForRoom(long RoomId)
    {
        var query = $@"SELECT * FROM roomservicestaff WHERE staff_id = @RoomId";
        using (var con = NewConnection)
            return (await con.QueryAsync<RoomServiceStaffDTO>(query, new { RoomId })).AsList();
    }



    public async Task<Rooms> GetById(long RoomId)

    {
        var query = $@"SELECT * FROM rooms WHERE room_id = @RoomId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Rooms>(query, new { RoomId });
    }

    public async Task<List<Rooms>> GetList()
    {
        var query = $@"SELECT * FROM rooms ";
        List<Rooms> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<Rooms>(query)).AsList();
        return result;
    }

    public async Task<bool> Update(Rooms Item)
    {
        var query = $@"UPDATE rooms SET room_type = @RoomType, room_no = @RoomNo, staff_id = @StaffId WHERE room_id = @RoomId";
        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }
}