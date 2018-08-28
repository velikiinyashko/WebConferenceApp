using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models
{
    public class Subsrube
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public List<Room> Rooms { get; set; }

        public Subsrube()
        {
            Rooms = new List<Room>();
        }
    }
}
