using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class SellBill
{
    public int DocId { get; set; }

    public string? Customer { get; set; }

    public string? CusPhone { get; set; }

    public string? CusAddress { get; set; }

    public double? Payment { get; set; }

    public int TaxId { get; set; }

    public int BraId { get; set; }

    public virtual Branch Bra { get; set; } = null!;

    public virtual Tax Tax { get; set; } = null!;
}
