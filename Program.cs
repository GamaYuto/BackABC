using Api_1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



//configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://wondrous-otter-678a4a.netlify.app","http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapScalarApiReference();
    app.MapOpenApi();
}
//politica CORS
app.UseCors("AllowSpecificOrigin")
; app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
