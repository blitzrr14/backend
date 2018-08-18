using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace common.models
{

    public class AddressDto
    {

        public int Id {get;set;}
        [MaxLength(100)]
        public string street { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }

    }


}
