using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace common.models
{

    public class UserRoleDto
    {


        [MaxLength(100)]
        public RolesDto Role {get;set;}

        public int UserID {get;set;}
        public int RoleID {get;set;}

        
    }



}
