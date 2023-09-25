using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class InvestmentRec
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public DateTime? Time { get; set; }

    public string? Desc { get; set; }

    public double? Amount { get; set; }

    public int Uid { get; set; }
}
