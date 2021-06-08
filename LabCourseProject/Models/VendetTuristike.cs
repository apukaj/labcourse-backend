using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class VendetTuristike
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Location
        {
            get; set;
        }
    }
}