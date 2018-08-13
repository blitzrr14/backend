using System;
using System.ComponentModel.DataAnnotations;

namespace common.models
{
    
    public class PetDto
    {
        public int Id {get;set;}
        public CategoryDto category { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(50)]
        public string photoUrls { get; set; }
        public TagDto tags { get; set; }
        [MaxLength(50)]
        public string status { get; set; }

        
    }

    public class CategoryDto
    {

        public int Id {get;set;}
        [MaxLength(100)]
        public string name { get; set; }
    }

    public class TagDto 
    {
         public int Id {get;set;}
        [MaxLength(100)]
        public string name { get; set; }
    }
}