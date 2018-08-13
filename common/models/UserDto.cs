using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace common.models
{

    public class UserDto
    {

        public int Id {get;set;}
        public RoleDto role { get; set; }
        [MaxLength(100),Required]
        public string fullname { get; set; }
        [MaxLength(50),Required]
        public string Username { get; set; }
        [MaxLength(50),Required]
        public string Password { get; set; }
        public int isActivate {get;set;} = 1;
        public AddressDto address { get; set; }
        
        
    }

    public class AddressDto
    {

        public int Id {get;set;}
        [MaxLength(100)]
        public string street { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
    }

    public class RoleDto
    {
        public int Id {get;set;}
        [MaxLength(50)]
        public string name { get; set; }
    }


}
