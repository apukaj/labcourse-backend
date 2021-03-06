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
        public string city { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        [NotMapped]
        public List<string> facilities { get; set; }
    }
}
