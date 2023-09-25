using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Product
{
    public int ProId { get; set; }

    public string? Name { get; set; }

    public double? CtrPrice { get; set; }

    public double? InPrice { get; set; }

    public double? OutPrice { get; set; }

    public int? NumInBranch { get; set; }

    public int PnId { get; set; }

    public int BraId { get; set; }

    public virtual Partner Pn { get; set; } = null!;

    public virtual ProductBuyBill Pro { get; set; } = null!;

    public virtual ProductSellBill ProNavigation { get; set; } = null!;
}
