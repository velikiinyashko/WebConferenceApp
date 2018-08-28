using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis_fullend.Models
{
    public class TypeAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }

        public TypeAccount()
        {
            Accounts = new List<Account>();
        }
    }
}
