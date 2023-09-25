using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Summary
{
    public int Id { get; set; }

    public string? Term { get; set; }

    public string? Detail { get; set; }

    public string? Balance { get; set; }

    public int TaxId { get; set; }

    public virtual Tax Tax { get; set; } = null!;
}
