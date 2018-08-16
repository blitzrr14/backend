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
        public int isActivate {get;set;} = 1;
        public PersonDto Person { get; set; }
        public byte[] RowVersion { get;set; }
        public DateTime Created { get;set; } = DateTime.Now;
        public DateTime Updated { get;set;} = DateTime.Now;
        public string CreatedBy { get;set;} = "SYSTEM";
         public virtual List<RolesDto> Roles {get;set;}
        
        
    }


}
