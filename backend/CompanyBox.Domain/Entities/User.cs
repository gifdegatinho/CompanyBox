namespace CompanyBox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
	public User()
	{
		Id = Guid.NewGuid();
		Suggestions = new List<Suggestion>();
		Votes = new List<Vote>();
		Comments = new List<Comment>();
		SentFeedbacks = new List<Feedback>();
		ReceivedFeedbacks = new List<Feedback>();
		Notifications = new List<Notification>();
	}

	[Key]
	public Guid Id { get; set; }

	[Required, MaxLength(100)]
	public string Name { get; set; } = string.Empty;

	[Required, MaxLength(100), EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required, MaxLength(512)]
	public string PasswordHash { get; set; } = string.Empty;

	public int Score { get; set; }

	public bool IsActive { get; set; }

	public Guid RoleId { get; set; }
	[ForeignKey("RoleId")]
	public virtual Role? Role { get; set; }
	
	public Guid PositionId { get; set; }
	[ForeignKey("PositionId")]
	public virtual Position? Position { get; set; }

	public virtual ICollection<Suggestion> Suggestions { get; set; }
	public virtual ICollection<Vote> Votes { get; set; }
	public virtual ICollection<Comment> Comments { get; set; }
	public virtual ICollection<Notification> Notifications { get; set; }

	[InverseProperty("Sender")]
	public virtual ICollection<Feedback> SentFeedbacks { get; set; }

	[InverseProperty("Recipient")]
	public virtual ICollection<Feedback> ReceivedFeedbacks { get; set; }
}