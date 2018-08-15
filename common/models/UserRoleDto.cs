using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace common.models
{

    public class UserRoleDto
    {

        public int Id {get;set;}

        [MaxLength(100)]
        public SysUserDto User { get; set; }
        public RolesDto Role {get;set;}
        public byte[] RowVersion { get;set; }
        public DateTime Created { get;set; } = DateTime.Now;
        public DateTime Updated { get;set;} = DateTime.Now;
        public string CreatedBy { get;set;} = "SYSTEM";
        
    }



}
