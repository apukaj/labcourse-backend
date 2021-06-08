using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCourseProject.Models
{
    public class Room
    {
        public int Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }

        public string StatusOfRoom
        {
            get; set;
        }
        public string DateOfJoining
        {
            get; set;
        }
        public string DateOfExit
        {
            get; set;
        }

        public int Price
        {
            get; set;
        }
    }

}