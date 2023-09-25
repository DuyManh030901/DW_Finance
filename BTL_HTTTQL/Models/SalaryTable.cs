using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class SalaryTable
{
    public int Stid { get; set; }

    public double? Total { get; set; }

    public string? Note { get; set; }

    public DateTime? Time { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
