﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using speaklis_fullend.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace speaklis_fullend.Models.Billing
{
    public class Contract
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public DateTime CteateTime { get; set; }
        [Column(TypeName = "numeric(18,4)")]
        public decimal Balance { get; set; }

        public List<Payment> Payments { get; set; }

        public int? AccountId { get; set; }
        public Account Account { get; set; }

        public Contract()
        {
            Payments = new List<Payment>();
        }
    }
}
