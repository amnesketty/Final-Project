using lounga.Data;
using lounga.Services.FlightService;
using lounga.Services.AuthServices;
using lounga.Services.FacilitiesFlightService;
using lounga.Services.FacilitiesHotelServices;
using lounga.Services.HotelServices;
using lounga.Services.RoomServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using lounga.Services.BookingHotelServices;
using lounga.Services.FileService;
using lounga.Services.BookingFlightService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = "Standard Authorization Header using the Bearer Scheme, e.g. \"Bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<DataContext>(options => 
    //options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    options.UseNpgsql("Host=ec2-34-247-72-29.eu-west-1.compute.amazonaws.com;Database=d4pvpj44rchrgm;Username=tjyggitmlrcyvx;Password=c543c1b9affddc1bfa18e4a47c4d520265e503a4dee3f9f38829ce971ba07cb4"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IFacilitiesFlightService, FacilitiesFlightService>();
builder.Services.AddScoped<IBookingFlightService, BookingFlightService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IFacilitiesHotelService, FacilitiesHotelService>();
builder.Services.AddScoped<IBookingHotelService, BookingHotelService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGetBookedHotelService, GetBookedHotelService>();
builder.Services.AddScoped<IFindHotelService, FindHotelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
