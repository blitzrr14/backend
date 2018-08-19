using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("ST_Address")]
    public class Address : Entity<int>
    {

        [MaxLength(100)]
        public string street { get; set; }
        [MaxLength(10)]
        public string zipcode { get; set; }
        [MaxLength(50)]
        public string city { get; set; }
        [MaxLength(50)]
        public string housenumber {get;set;}
        [MaxLength(50)]
        public string province {get;set;}
        [MaxLength(50)]
        public string country {get;set;}
    }


}
