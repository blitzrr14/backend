using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class Transaction : Entity<int>
    { 
        public SysUser User { get; set; }
        public Raffle Raffle { get; set; }
        public TransType TransType {get;set;}

    }

}
