using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models
{
    public class RoomTags
    {
        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public int? TagsId { get; set; }
        public Tags Tags { get; set; }
    }
}
