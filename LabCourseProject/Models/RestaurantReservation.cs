using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class RestaurantReservation
    {
        public int Id
        {
            get; set;
        }
        public int GuestCount
        {
            get; set;
        }
        public DateTime ReservationTime
        {
            get; set;
        }
        public string Restaurant { get; set; }
    }
}
