using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Rnc { get; set; } = null!;

    public string? Email { get; set; }

    public string? Logo { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<CompanyUsr100> CompanyUsr100s { get; set; } = new List<CompanyUsr100>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
