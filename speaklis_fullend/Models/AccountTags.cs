using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis_fullend.Models
{
    public class AccountTags
    {
        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public int? TagsId { get; set; }
        public Tags Tags { get; set; }

    }
}
