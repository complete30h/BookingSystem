using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class OpenAirConcert: Concert
    {
        public string? HeadLiner { get; set; }
        public string? DrivingDirections { get; set; }
    }
}
