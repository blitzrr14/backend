using System;
using System.ComponentModel.DataAnnotations;
using dal.interfaces;

namespace dal.Abstracts 
{
    public abstract class Entity<T> : IEntity<T>
    {
        [Key]
        public T Id {get;set;}
        [Timestamp]
        public byte[] RowVersion { get;set; }
        public DateTime CreatedAt { get;set; } = DateTime.Now;
        public DateTime? UpdatedAt { get;set;} = null;
        public DateTime? DeletedAt { get;set;} = null;
        public string CreatedBy { get;set;} = "SYSTEM";

    }

}