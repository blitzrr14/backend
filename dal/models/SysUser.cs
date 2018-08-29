using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("AS_User")]
    public class SysUser : Entity<int>
    {

        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public int isActivate {get;set;} = 1;
        public Person person { get; set; }
        public ICollection<UserRole> UserRoles {get;set;}



    }


}
