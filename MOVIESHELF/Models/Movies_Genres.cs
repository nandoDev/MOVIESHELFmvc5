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
    
    public partial class Movies_Genres
    {
        public int IdMovie_Genre { get; set; }
        public int idGenre { get; set; }
        public int idMovie { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Movies1 Movies1 { get; set; }
    }
}
