using System;
using System.Collections.Generic;

namespace Data.Models.IAS;

public partial class Company
{
    public int Id { get; set; }

    public string BusinessName { get; set; } = null!;

    public string Tradename { get; set; } = null!;

    public int BaseCurrencyId { get; set; }

    public int DefaultCurrencyId { get; set; }

    public int? DefaultTaxGroupId { get; set; }

    public int? DefaultPriceLevelId { get; set; }

    public string Rnc { get; set; } = null!;

    public int? TaxRegimeId { get; set; }

    public int CountryId { get; set; }

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

    public int TimeZoneId { get; set; }

    public int NativePrintFormatId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

    public virtual Currency BaseCurrency { get; set; } = null!;

    public virtual ICollection<CompanyUsr100> CompanyUsr100s { get; set; } = new List<CompanyUsr100>();

    public virtual Country Country { get; set; } = null!;

    public virtual Currency DefaultCurrency { get; set; } = null!;

    public virtual NativePrintFormat NativePrintFormat { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual TimeZone TimeZone { get; set; } = null!;
}
