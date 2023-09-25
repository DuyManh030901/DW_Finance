using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class BalanceRec
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public string? Amount { get; set; }

    public string? Term { get; set; }

    public int? BraId { get; set; }

    public int? Accode { get; set; }

    public double? Accr { get; set; }

    public double? Acdr { get; set; }

    public virtual Account? AccodeNavigation { get; set; }

    public virtual Branch? Bra { get; set; }
}
