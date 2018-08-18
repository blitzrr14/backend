using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace common.models
{

    public class PersonDto
    {

        public int Id {get;set;}

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        public AddressDto Address {get;set;}
        public int ContactNo {get;set;}
        [MaxLength(10)]
        public string Gender {get;set;}


        
    }



}
