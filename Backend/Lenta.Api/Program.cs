using Lenta.Api;
using Lenta.Api.Interfaces;
using Lenta.Api.Middleware;
using Lenta.Api.Services;
using Lenta.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySql"),
            new MySqlServerVersion(new Version(8, 0, 11)));
});
builder.Services.AddAutoMapper(typeof(ApiMappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseValidationException();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();
app.Run();