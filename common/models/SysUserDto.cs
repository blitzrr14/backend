using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace common.models
{

    public class SysUserDto
    {

        public int Id {get;set;}

        [MaxLength(50),Required]
        public string Username { get; set; }
        
        [MaxLength(50),Required]
        public string Password { get; set; }
        [MaxLength(50),Required]
        public string Email { get; set; }
        public int isActivate {get;set;} = 1;
        public PersonDto Person { get; set; }
        public virtual IEnumerable<UserRoleDto> UserRoles {get;set;}


    }


}
