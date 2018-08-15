using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using dal.Abstracts;


namespace dal.models
{

    public class Person : Entity<int>
    {

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        public Address Address {get;set;}
        public int ContactNo {get;set;}
        [MaxLength(10)]
        public string Gender {get;set;}
        
    }








}
