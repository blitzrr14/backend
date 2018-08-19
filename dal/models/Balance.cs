using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("TR_Balance")]
    public class Balance : Entity<int>
    {
        public SysUser user {get;set;}
        public decimal Points {get;set;}
        public decimal Wallet {get;set;}
        public decimal Credits {get;set;}

      
    }


}
