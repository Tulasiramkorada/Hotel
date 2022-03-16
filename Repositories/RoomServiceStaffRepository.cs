using Dapper;
using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;

namespace Hotel.Repositories;

public interface IRoomServiceStaffRepository
{
    Task<RoomServiceStaff> Create(RoomServiceStaff Item);
    Task<bool> Update(RoomServiceStaff Item);
    Task<bool> Delete(long RoomServiceStaffId);
    Task<RoomServiceStaff> GetById(long RoomServiceStaffId);
    Task<List<RoomServiceStaff>> GetList();
    Task<List<RoomServiceStaff>> GetAllForRooms(long RoomId);



}
public class RoomServiceStaffRepository : BaseRepository, IRoomServiceStaffRepository

{
    public RoomServiceStaffRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<RoomServiceStaff> Create(RoomServiceStaff Item)
    {
        var query = $@"INSERT INTO roomservicestaff(staff_id, staff_name, staff_address, contact_number) VALUES (@StaffId, @StaffName, @StaffAddress, @ContactNumber) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<RoomServiceStaff>(query, Item);
            return res;

        }
    }


    public async Task<bool> Delete(long StaffId)
    {
        var query = $@"DELETE FROM roomservicestaff WHERE staff_id=@StaffId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { StaffId });
            return result > 0;

        }
    }

    public async Task<List<RoomServiceStaff>> GetAllForRooms(long RoomId)
    {
        var query = $@"SELECT * FROM roomservicestaff WHERE room_id = RoomId";
        using (var con = NewConnection)
            return (await con.QueryAsync<RoomServiceStaff>(query, new { RoomId })).AsList();
    }

    public async Task<RoomServiceStaff> GetById(long StaffId)

    {
        var query = $@"SELECT * FROM roomservicestaff WHERE staff_id = @StaffId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<RoomServiceStaff>(query, new { StaffId });
    }

    public async Task<List<RoomServiceStaff>> GetList()
    {
        var query = $@"SELECT * FROM roomservicestaff";
        List<RoomServiceStaff> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<RoomServiceStaff>(query)).AsList();
        return result;
    }

    public async Task<bool> Update(RoomServiceStaff Item)
    {
        var query = $@"UPDATE roomservicestaff SET staff_name=@StaffName, staff_address=@StaffAddress, staff_id=@StaffId WHERE staff_id=@StaffId";
        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }

    // Task<RoomServiceStaff> IRoomServiceStaffRepository.GetById(long RoomServiceStaffId)
    // {
    //     throw new NotImplementedException();
    // }



    //     Task<RoomServiceStaff> IRoomServiceStaffRepository.GetById(long RoomServiceStaffId)
    // {
    //         throw new NotImplementedException();
    // }
}


