namespace dal.interfaces
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IEntity 
    {
        DateTime CreatedAt {get;set;}
        DateTime? UpdatedAt {get;set;}
        DateTime? DeletedAt {get;set;}
        string CreatedBy {get;set;}
    }

    public interface IEntity<T> : IEntity
    {
        T Id {get;set;}
    }
    
}