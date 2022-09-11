using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lounga.Models
{
    public class Aircraft
    {
        public int Id {get; set;}
        public string AircraftsType {get; set;} = string.Empty;
        public string SeatLayout {get; set;} = string.Empty;
        public string SeatPitch {get; set;} = string.Empty;
        public int SeatCapacity {get;set;}
    }
}