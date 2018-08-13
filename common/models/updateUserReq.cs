using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace common.models
{

    public class updateUserReq
    {

        public int Id {get;set;}

        [MaxLength(100),Required]
        public string fullname { get; set; }
        [MaxLength(50),Required]
        public string Username { get; set; }
        public AddressDto address { get; set; }
        
        
    }




}
