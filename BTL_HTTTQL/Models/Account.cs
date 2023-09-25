using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Account
{
    public int Acid { get; set; }

    public int Accode { get; set; }

    public string? Name { get; set; }

    public int? Acper { get; set; }

    public string? Desc { get; set; }

    public virtual ICollection<BalanceRec> BalanceRecs { get; set; } = new List<BalanceRec>();

    public virtual ICollection<LendRec> LendRecs { get; set; } = new List<LendRec>();

    public virtual ICollection<LoanRec> LoanRecs { get; set; } = new List<LoanRec>();
}
