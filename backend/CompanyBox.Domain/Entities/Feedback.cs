namespace CompanyBox.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Feedback
{
    public Feedback()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Message { get; set; } = string.Empty;

    [Column(TypeName = "Date")]
    public DateTime CreationDate { get; set; }

    public bool IsRead { get; set; }

    public Guid SenderId { get; set; }
    [ForeignKey("SenderId")]
    public virtual User? Sender { get; set; }

    public Guid RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public virtual User? Recipient { get; set; }
}