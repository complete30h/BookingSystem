using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public  User? User { get; set; }
        public int ConcertId { get; set; }
        public Concert? Concert { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
