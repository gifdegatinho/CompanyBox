namespace CompanyBox.Domain.Entities;
using System;

public class SuggestionTag
{
    public Guid SuggestionId { get; set; }
    public virtual Suggestion Suggestion { get; set; }

    public Guid TagId { get; set; }
    public virtual Tag Tag { get; set; }
}