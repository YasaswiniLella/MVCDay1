using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCDay1.Models.CustomAttributes;

namespace MVCDay1.Models
{
    public class Customer
    {
        
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Customdob]
        public DateTime? DateofBirth { get; set; }
        
        [Required]
        public string Address { get; set; }
        public Membership Membership { get; set; }
        [Required]
        [Display(Name = "Membership Type")]

        public int MembershipId { get; set; }
        [Required]
        public string Gender { get; set; }
        
    }
}