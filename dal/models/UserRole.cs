using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("AS_UserRole")]
    public class UserRole : CommonEntity
    {
        
        public int UserID {get;set;}
        [ForeignKey("UserID")]
         public SysUser User { get; set; }
         public int RoleID {get;set;}
         [ForeignKey("RoleID")]
         public Role Role {get;set;}

    }


}
