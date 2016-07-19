using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace chsakell_SPA.Models
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfMovies { get; set; }
    }
}