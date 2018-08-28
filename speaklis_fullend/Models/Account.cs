using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using speaklis_fullend.Models.Billing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace speaklis_fullend.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string SurName { get; set; }
        
        public Avatar Avatar { get; set; }

        public Subsrube Subsrube { get; set; }

        public List<AccountTags> AccountTags { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public int? TypeAccountId { get; set; }
        public TypeAccount TypeAccount { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public Contract Contract { get; set; }

        public List<Room> Rooms { get; set; }

        public Account()
        {
            Rooms = new List<Room>();
            AccountTags = new List<Models.AccountTags>();
        }
    }
}
