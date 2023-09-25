using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Receipt
{
    public int DocId { get; set; }

    public string? ReceiptType { get; set; }

    public string? Desc { get; set; }
}
