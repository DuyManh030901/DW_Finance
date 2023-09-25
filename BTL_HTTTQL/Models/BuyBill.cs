using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class BuyBill
{
    public int DocId { get; set; }

    public double? Payment { get; set; }

    public int BraId { get; set; }

    public virtual Branch Bra { get; set; } = null!;
}
