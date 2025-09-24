namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Position
{
    public Position()
    {
        Users = new List<User>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<User> Users { get; set; }
}