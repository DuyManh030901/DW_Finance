using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class LendPayment
{
    public int LendPaymentId { get; set; }

    public double? InterestAmt { get; set; }

    public string? PaymentAmt { get; set; }

    public DateTime? Time { get; set; }

    public string? Payment { get; set; }

    public string? Account { get; set; }

    public string? AccountDr { get; set; }

    public string? AccountCr { get; set; }

    public int LendRecId { get; set; }

    public virtual LendRec LendRec { get; set; } = null!;
}
