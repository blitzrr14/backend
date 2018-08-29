using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("ST_Role")]
    public class Role : Entity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public List<UserRole> UserRoles {get;set;}

    }

}
