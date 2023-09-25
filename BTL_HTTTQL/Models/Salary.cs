using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Salary
{
    public int Id { get; set; }

    public double? Deduction { get; set; }

    public double? Sum { get; set; }

    public double? DayOfNum { get; set; }

    public double? Reward { get; set; }

    public int EmpId { get; set; }

    public int Stid { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual SalaryTable St { get; set; } = null!;
}
