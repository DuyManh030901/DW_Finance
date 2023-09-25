using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Department
{
    public int Dpmid { get; set; }

    public string? Name { get; set; }

    public string? NumOfEmployees { get; set; }

    public int BraId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
