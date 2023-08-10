using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class Currency
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Company> CompanyBaseCurrencyNavigations { get; set; } = new List<Company>();

    public virtual ICollection<Company> CompanyDefaultCurrencyNavigations { get; set; } = new List<Company>();
}
