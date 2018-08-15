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
        public byte[] RowVersion { get;set; }
        public DateTime Created { get;set; } = DateTime.Now;
        public DateTime Updated { get;set;} = DateTime.Now;
        public string CreatedBy { get;set;} = "SYSTEM";
    }


}
