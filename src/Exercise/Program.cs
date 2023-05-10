using Microsoft.EntityFrameworkCore;
using Exercise.Data;
using Exercise.Data.Repositories;
using Exercise.Domain.Interfaces;
using Exercise.Domain.Services;
using Exercise.Helpers;
using Exercise.Data.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<GlobalDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Exercise")));
builder.Services.AddAutoMapper(typeof(DataLayerMapperProfile),
    typeof(ControllerMapperProfile));
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
