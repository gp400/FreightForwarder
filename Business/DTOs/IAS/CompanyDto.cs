using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.IAS
{
    public class CompanyDto
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

        public int UserId { get; set; }
    }
}
