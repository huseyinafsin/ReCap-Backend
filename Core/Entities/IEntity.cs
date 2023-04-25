using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    //IEntity implement eden class bir veritabanı tablosudur
    public interface IEntity
    {
       
        Guid Id { get; }
    }
}
