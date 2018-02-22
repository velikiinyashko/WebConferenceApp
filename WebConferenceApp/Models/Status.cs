using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConferenceApp.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Room> Rooms { get; set; }

        public Status()
        {
            Rooms = new List<Room>();
        }
    }
}
