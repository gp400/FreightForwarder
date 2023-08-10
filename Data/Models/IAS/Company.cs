using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class Company
{
    public int Id { get; set; }

    public string BusinessName { get; set; } = null!;

    public string Tradename { get; set; } = null!;

    public int BaseCurrency { get; set; }

    public int DefaultCurrency { get; set; }

    public int? DefaultTaxGroup { get; set; }

    public int? DefaultPriceLevel { get; set; }

    public string Rnc { get; set; } = null!;

    public int? TaxRegime { get; set; }

    public int Country { get; set; }

    public string Phone { get; set; } = null!;

    public string? AltPhone { get; set; }

    public string? Fax { get; set; }

    public string Email { get; set; } = null!;

    public string? Website { get; set; }

    public string? Facebook { get; set; }

    public string? Twitter { get; set; }

    public string? YouTube { get; set; }

    public string? Instagram { get; set; }

    public string Address { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string? Logo { get; set; }

    public string? Slogan { get; set; }

    public string? InvoicesNotes { get; set; }

    public int FirstMonthFiscalYear { get; set; }

    public string? DateFormat { get; set; }

    public int TimeZone { get; set; }

    public int NativePrintFormat { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Currency BaseCurrencyNavigation { get; set; } = null!;

    public virtual ICollection<CompanyUsr100> CompanyUsr100s { get; set; } = new List<CompanyUsr100>();

    public virtual Currency DefaultCurrencyNavigation { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
