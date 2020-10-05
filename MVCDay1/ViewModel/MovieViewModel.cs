using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDay1.Models;

namespace MVCDay1.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> GetGenres { get; set; }
    }
}