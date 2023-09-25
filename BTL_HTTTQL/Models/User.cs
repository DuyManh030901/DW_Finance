using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class User
{
    public int Uid { get; set; }

    public string? Usename { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Sex { get; set; }

    public int BraId { get; set; }

    public virtual Branch Bra { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
