using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace common.models
{

    public class changePasswordReq
    {

        public string Username { get; set; }
        [MaxLength(50),Required]
        public string Password { get; set; }
        [MaxLength(50),Required]
        public string NewPassword { get; set; }
        
        
    }


}
