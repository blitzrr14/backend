using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class SysUser : Entity<int>
    {

        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public int isActivate {get;set;} = 1;
        public Person Person { get; set; }
        
    }


}
