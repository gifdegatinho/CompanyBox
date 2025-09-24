namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Tag
{
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<SuggestionTag> SuggestionTags { get; set; } = new List<SuggestionTag>();
}