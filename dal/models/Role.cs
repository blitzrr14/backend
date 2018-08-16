using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class Roles : Entity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public virtual ICollection<SysUser> users {get; set;}
        public virtual ICollection<UserRole> UserRoles {get;set;}
    }

}
