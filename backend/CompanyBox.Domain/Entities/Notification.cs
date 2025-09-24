namespace CompanyBox.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notification
{
    public Notification()
    {
        Id = Guid.NewGuid();
        Date = DateTime.UtcNow;
    }

    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(500)]
    public string Message { get; set; } = string.Empty;

    [Column(TypeName = "Date")]
    public DateTime Date { get; set; }

    public bool IsRead { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}