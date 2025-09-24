namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        SuggestionCategories = new List<SuggestionCategory>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Description { get; set; }

    public virtual ICollection<SuggestionCategory> SuggestionCategories { get; set; }
}