using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("AS_UserRole")]
    public class UserRole : Entity<int>
    {
         public SysUser User { get; set; }
         public Role Role {get;set;}

    }


}
