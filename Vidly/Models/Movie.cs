﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Number In Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name="Genre Type")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}