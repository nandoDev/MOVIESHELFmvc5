//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MOVIESHELF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movies1
    {
        public Movies1()
        {
            this.Movie_Actors = new HashSet<Movie_Actors>();
            this.Movie_Country = new HashSet<Movie_Country>();
            this.Movie_Director = new HashSet<Movie_Director>();
            this.Movie_Users = new HashSet<Movie_Users>();
            this.Movies_Genres = new HashSet<Movies_Genres>();
        }
    
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string PosterUrl { get; set; }
        public string ImdbId { get; set; }
    
        public virtual ICollection<Movie_Actors> Movie_Actors { get; set; }
        public virtual ICollection<Movie_Country> Movie_Country { get; set; }
        public virtual ICollection<Movie_Director> Movie_Director { get; set; }
        public virtual ICollection<Movie_Users> Movie_Users { get; set; }
        public virtual ICollection<Movies_Genres> Movies_Genres { get; set; }
    }
}
