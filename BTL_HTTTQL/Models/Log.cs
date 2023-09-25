using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Log
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Action { get; set; }

    public DateTime? Time { get; set; }

    public int Uid { get; set; }

    public virtual User UidNavigation { get; set; } = null!;
}
