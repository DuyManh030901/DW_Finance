using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class Branch
{
    public int BraId { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<BalanceRec> BalanceRecs { get; set; } = new List<BalanceRec>();

    public virtual ICollection<BuyBill> BuyBills { get; set; } = new List<BuyBill>();

    public virtual ICollection<LendRec> LendRecs { get; set; } = new List<LendRec>();

    public virtual ICollection<LoanRec> LoanRecs { get; set; } = new List<LoanRec>();

    public virtual ICollection<SellBill> SellBills { get; set; } = new List<SellBill>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
