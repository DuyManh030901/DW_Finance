using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Partner
{
    public int PnId { get; set; }

    public string? Name { get; set; }

    public int? TaxId { get; set; }

    public string? Address { get; set; }

    public string? Desc { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LendRec> LendRecs { get; set; } = new List<LendRec>();

    public virtual ICollection<LoanRec> LoanRecs { get; set; } = new List<LoanRec>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
