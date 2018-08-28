using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }
    }
}
