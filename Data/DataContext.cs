using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lounga.Model;
using Lounga.Models;
using Microsoft.EntityFrameworkCore;

namespace lounga.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Hotel> Hotels {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Airline> Airlines {get; set;}
    }
}