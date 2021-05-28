using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomType.Models
{
    public class Room
    {
        public int RoomId
        {
            get; set;
        }
        public string RoomName
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
