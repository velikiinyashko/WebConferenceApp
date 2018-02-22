using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConferenceApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Account> Accounts { get; set; }

        public Role()
        {
            Accounts = new List<Models.Account>();
        }
    }
}
