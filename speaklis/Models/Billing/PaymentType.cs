using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speaklis.Models.Billing
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Payment> Payments { get; set; }

        public PaymentType()
        {
            Payments = new List<Payment>();
        }
    }
}
