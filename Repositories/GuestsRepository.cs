using hotel.Models;
using Dapper;
using hotel.Repositories;

namespace Hotel.Repositories;

public interface IGuestsRepository
{
    Task<Guests> Create(Guests Item);
    Task<bool> Update(Guests Item);
    Task<bool> Delete(int GuestId);
    Task<Guests> GetById(int GuestId);
    Task<List<Guests>> GetList();

}
public class GuestRepository : BaseRepository, IGuestsRepository
{
    public GuestRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Guests> Create(Guests Item)
    {
        var query = $@"INSERT INTO guest (guest_id, guest_name, guest_details) VALUES (@GuestId, @GuestName, @GuestDetails) RETURNING * ";
        using (var connection = NewConnection)
        {
            var res = await connection.QuerySingleOrDefaultAsync<Guests>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(int GuestId)
    {
        var query = $@"DELETE FROM guest WHERE guest_id=@GuestId";

        using (var connection = NewConnection)
        {
            var res = await connection.ExecuteAsync(query, new { GuestId });
            return res > 0;
        }
    }



    public async Task<Guests> GetById(int GuestId)
    {
        var query = $@"SELECT * FROM guest
        WHERE guest_id = @GuestId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Guests>(query, new { GuestId });
    }



    public async Task<List<Guests>> GetList()
    {
        var query = $@"SELECT * FROM guest";

        List<Guests> res;
        using (var con = NewConnection)
            res = (await con.QueryAsync<Guests>(query)).AsList();
        return res;

    }

    public async Task<bool> Update(Guests Item)
    {
        var query = $@"UPDATE guest SET  guest_name=@GuestName,guest_details=@GuestDetails WHERE guest_id=@GuestId ";
        using (var connection = NewConnection)
        {
            var Count = await connection.ExecuteAsync(query, Item);
            return Count == 1;
        }
    }



}