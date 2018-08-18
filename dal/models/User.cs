using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class User : Entity<int>
    {

        public Roles role { get; set; }
        [MaxLength(100)]
        public string fullname { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public int isActivate {get;set;} = 1;
        public Address address { get; set; }
        
    }


    public class Role : Entity<int>
    {
        [MaxLength(100)]
        public string name { get; set; }
    }


}
