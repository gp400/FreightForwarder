using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Description { get; set; }

    public int CompanyId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<Usr100Role> Usr100Roles { get; set; } = new List<Usr100Role>();
}
