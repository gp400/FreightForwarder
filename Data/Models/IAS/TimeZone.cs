using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class TimeZone
{
    public int Id { get; set; }

    public string ZoneName { get; set; } = null!;

    public int Utcdifference { get; set; }

    public string Abbreviation { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
