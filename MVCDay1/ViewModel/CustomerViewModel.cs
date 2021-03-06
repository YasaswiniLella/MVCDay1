﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDay1.Models;

namespace MVCDay1.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<Membership> GetMembership { get; set; }
        public List<SelectListItem> Gender { get; set; }
    }
}