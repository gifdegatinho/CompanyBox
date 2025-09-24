namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    public Comment()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        Replies = new List<Comment>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(1000)]
    public string Text { get; set; } = string.Empty;

    [Column(TypeName = "Date")]
    public DateTime CreationDate { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    public Guid SuggestionId { get; set; }
    [ForeignKey("SuggestionId")]
    public virtual Suggestion? Suggestion { get; set; }

    public Guid? ParentCommentId { get; set; }
    [ForeignKey("ParentCommentId")]
    public virtual Comment? ParentComment { get; set; }

    public virtual ICollection<Comment> Replies { get; set; }
}