using lounga.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => 
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    options.UseNpgsql("Host=ec2-34-247-72-29.eu-west-1.compute.amazonaws.com;Database=d4pvpj44rchrgm;Username=tjyggitmlrcyvx;Password=c543c1b9affddc1bfa18e4a47c4d520265e503a4dee3f9f38829ce971ba07cb4"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
