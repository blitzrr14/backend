using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class UserRole : Entity<int>
    {
        public SysUser User { get; set; }
        public Role Role {get;set;}
        
    }


}
