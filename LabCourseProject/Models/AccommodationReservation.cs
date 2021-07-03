using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class AccommodationReservation
    {
        public int Id
        {
            get; set;
        }
        public string RoomType
        {
            get; set;
        }
        public DateTime CheckIn
        {
            get; set;
        }

        public DateTime CheckOut
        {
            get; set;
        }

        public string Accommodation { get; set; }
    }
}
