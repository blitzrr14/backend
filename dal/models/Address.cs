using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class Address : Entity<int>
    {

        [MaxLength(100)]
        public string street { get; set; }
        [MaxLength(10)]
        public string zipcode { get; set; }
        [MaxLength(50)]
        public string city { get; set; }
    }


}
