using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Sex { get; set; }

    public int CardId { get; set; }

    public string? Bank { get; set; }

    public int TaxId { get; set; }

    public int Dpmid { get; set; }

    public virtual Department Dpm { get; set; } = null!;

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual Tax Tax { get; set; } = null!;
}
