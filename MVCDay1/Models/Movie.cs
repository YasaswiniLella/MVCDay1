using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCDay1.Models.CustomAttributes;

namespace MVCDay1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Please enter movie name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [CustomReleaseDate]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Director Name")]
        [Required(ErrorMessage = "Please enter director name")]
        [StringLength(100)]
        public string DirectorName { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

    }
}