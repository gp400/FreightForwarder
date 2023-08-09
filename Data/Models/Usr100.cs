using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Usr100
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string? Picture { get; set; }

    public string? Observations { get; set; }

    public DateTime PasswordExpires { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<CompanyUsr100> CompanyUsr100s { get; set; } = new List<CompanyUsr100>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();

    public virtual ICollection<Usr100Role> Usr100Roles { get; set; } = new List<Usr100Role>();
}
