namespace CompanyBox.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Vote
{
    public Vote()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public int Value { get; set; } 

    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    public Guid SuggestionId { get; set; }
    [ForeignKey("SuggestionId")]
    public virtual Suggestion? Suggestion { get; set; }
}