using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDay1.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string MembershipType { get; set; }
        public float SignUpFee { get; set; }
        public string Duration { get; set; }
        public double Discount { get; set; }
    }
}