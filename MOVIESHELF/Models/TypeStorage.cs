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
    
    public partial class TypeStorage
    {
        public TypeStorage()
        {
            this.MovieUser_TypeStorage = new HashSet<MovieUser_TypeStorage>();
        }
    
        public int IdTypeStorage { get; set; }
        public string TypeStorage1 { get; set; }
    
        public virtual ICollection<MovieUser_TypeStorage> MovieUser_TypeStorage { get; set; }
    }
}
