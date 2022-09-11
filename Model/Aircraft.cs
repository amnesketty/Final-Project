using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lounga.Models
{
    public class Aircraft
    {
        public int Id {get; set;}
        public string? AircraftsType {get; set;}
        public string? SeatLayout {get; set;}
        public string? SeatPitch {get; set;}
        public int SeatCapacity {get;set;}
    }
}