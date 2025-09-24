namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Suggestion
{
    public Suggestion()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        Votes = new List<Vote>();
        Comments = new List<Comment>();
        SuggestionCategories = new List<SuggestionCategory>();
        SuggestionTags = new List<SuggestionTag>(); 
    }

    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(128)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "Date")]
    public DateTime CreationDate { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    public Guid StatusId { get; set; }
    [ForeignKey("StatusId")]
    public virtual Status? Status { get; set; }

    public virtual ICollection<Vote> Votes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<SuggestionCategory> SuggestionCategories { get; set; }
    public virtual ICollection<SuggestionTag> SuggestionTags { get; set; } 
}