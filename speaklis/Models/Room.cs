﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime BegTime { get; set; }
        public DateTime EndTime { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public List<RoomTags> RoomTags { get; set; }

        public int? StatusId { get; set; }
        public Status Status { get; set; }

        public Room()
        {
            RoomTags = new List<RoomTags>();
        }
    }
}
