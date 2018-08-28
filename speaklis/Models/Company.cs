using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Inn { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public List<Account> Accounts { get; set; }

        public Company()
        {
            Accounts = new List<Account>();
        }
    }
}
