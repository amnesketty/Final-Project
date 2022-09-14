using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;
using Microsoft.EntityFrameworkCore;

namespace lounga.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users {get; set; }
        public DbSet<Hotel> Hotels {get; set; }
        public DbSet<Room> Rooms {get; set; }
        public DbSet<FacilitiesHotel> FacilitiesHotels {get; set; }
        public DbSet<Photo> Photos {get; set; }
        public DbSet<BookingHotel> BookingHotels {get; set; }
        public DbSet<Guest> Guests {get; set; }
        public DbSet<Flight> Flights {get; set; }
        public DbSet<FacilitiesFlight> FacilitiesFlights {get; set; }
        public DbSet<BookingFlight> BookingFlights {get; set; }
        public DbSet<Passenger> Passengers {get; set; }
    }
}