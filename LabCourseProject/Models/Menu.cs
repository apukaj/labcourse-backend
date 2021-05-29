using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class Menu
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string name { get; set; }
            
    }
}
