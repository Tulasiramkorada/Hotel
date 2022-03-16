using hotel.Repositories;
using Hotel.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IRoomsRepository, RoomsRepository>();
builder.Services.AddTransient<IRoomServiceStaffRepository, RoomServiceStaffRepository>();
builder.Services.AddTransient<IGuestsRepository, GuestRepository>();
builder.Services.AddTransient<IStayScheduleRepository, StaySchedulesRepository>();

//builder.Services.AddTransient<IRoomServiceStaffRepository, RoomServiceStaffRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IRoomRepository, RoomRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
