using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConferenceApp.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AccountTags> AccountTags { get; set; }

        public Tags()
        {
            AccountTags = new List<AccountTags>();
        }
    }
}
