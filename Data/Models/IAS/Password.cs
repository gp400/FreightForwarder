using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class Password
{
    public int Id { get; set; }

    public string Password1 { get; set; } = null!;

    public int Usr100Id { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Usr100 Usr100 { get; set; } = null!;
}
