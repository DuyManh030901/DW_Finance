using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Tax
{
    public int TaxId { get; set; }

    public string? TaxType { get; set; }

    public double? Percentage { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<SellBill> SellBills { get; set; } = new List<SellBill>();

    public virtual ICollection<Summary> Summaries { get; set; } = new List<Summary>();
}
