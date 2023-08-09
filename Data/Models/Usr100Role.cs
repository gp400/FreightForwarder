using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Usr100Role
{
    public int Id { get; set; }

    public int Usr100Id { get; set; }

    public int RoleId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Usr100 Usr100 { get; set; } = null!;
}
