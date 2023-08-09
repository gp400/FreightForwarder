using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Membership
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? ApplicationId { get; set; }

    public string? Comment { get; set; }

    public string? Email { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int? FailedPasswordAnswerAttemptCount { get; set; }

    public DateTime? FailedPasswordAnswerAttemptWindowStart { get; set; }

    public int? FailedPasswordAttemptCount { get; set; }

    public DateTime? FailedPasswordAttemptWindowStart { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsLockedOut { get; set; }

    public DateTime? LastLockoutDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public string? MobilePin { get; set; }

    public string? Password { get; set; }

    public string? PasswordAnswer { get; set; }

    public int? PasswordFormat { get; set; }

    public string? PasswordQuestion { get; set; }

    public string? PasswordSalt { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? PasswordResetTokenLifetime { get; set; }

    public string? PasswordResetTokenExpired { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? EmailResetToken { get; set; }

    public string? EmailResetTokenExpired { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Usr100? User { get; set; }
}
