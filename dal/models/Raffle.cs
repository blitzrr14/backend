using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class Raffle : Entity<int>
    {
        public SysUser User { get; set; }
        public RaffleType RaffleType { get; set; }
        public DateTime? RaffleDate {get;set;}
    }

}
