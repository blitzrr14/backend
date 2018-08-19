using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dal.Abstracts;


namespace dal.models
{

    [Table("ST_Person")]
    public class Person : Entity<int>
    {

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        public Address Address1 {get;set;}
        public Address Address2 {get;set;}
        public int ContactNo {get;set;}
        [MaxLength(10)]
        public string Gender {get;set;}
        
    }








}
