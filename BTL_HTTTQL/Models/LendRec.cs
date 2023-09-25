using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class LendRec
{
    public int LendRecId { get; set; }

    public string? Desc { get; set; }

    public double? Amount { get; set; }

    public DateTime? Time { get; set; }

    public double? InterestRate { get; set; }

    public string? Expired { get; set; }

    public double? RecentAmt { get; set; }

    public int Uid { get; set; }

    public int PnId { get; set; }

    public int? BraId { get; set; }

    public int? Acid { get; set; }

    public virtual Account? Ac { get; set; }

    public virtual Branch? Bra { get; set; }

    public virtual Partner Pn { get; set; } = null!;
}
