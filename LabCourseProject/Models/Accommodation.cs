using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class Accommodation
    {
        public int id { get; set; }
        public string name { get; set; }
        public City city { get; set; }
        public string address { get; set; }
        public AccommodationType type { get; set; }
        public List<AccommodationFacility> facilities { get; set; }
    }
}
