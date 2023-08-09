using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class CompanyUsr100
{
    public int Id { get; set; }

    public int CompanyId { get; set; }

    public int Usr100Id { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Usr100 Usr100 { get; set; } = null!;
}
