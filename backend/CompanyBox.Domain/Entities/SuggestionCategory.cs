namespace CompanyBox.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SuggestionCategory
{
    public Guid SuggestionId { get; set; }
    [ForeignKey("SuggestionId")]
    public virtual Suggestion? Suggestion { get; set; }

    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
}