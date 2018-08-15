using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace common.models
{

    public class RolesDto
    {

        public int Id {get;set;}

      [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public byte[] RowVersion { get;set; }
        public DateTime Created { get;set; } = DateTime.Now;
        public DateTime Updated { get;set;} = DateTime.Now;
        public string CreatedBy { get;set;} = "SYSTEM";
        
    }



}
