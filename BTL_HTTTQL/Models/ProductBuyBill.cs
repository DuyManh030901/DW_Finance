using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class ProductBuyBill
{
    public int ProId { get; set; }

    public int DocId { get; set; }

    public int? Num { get; set; }

    public virtual Product? Product { get; set; }
}
