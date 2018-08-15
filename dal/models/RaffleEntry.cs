using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class RaffleEntry : Entity<int>
    {
        public Raffle Raffle { get; set; }
        public SysUser User { get; set; }
        public Transaction Transaction {get;set;}
    }


}
