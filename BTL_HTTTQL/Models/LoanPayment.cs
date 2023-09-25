using System;
using System.Collections.Generic;

namespace BTL_HTTTQL.Models;

public partial class LoanPayment
{
    public int LoanPaymentId { get; set; }

    public double? InterestAmt { get; set; }

    public string? PaymentAmt { get; set; }

    public DateTime? Time { get; set; }

    public string? Payment { get; set; }

    public string? Account { get; set; }

    public string? AccountDr { get; set; }

    public string? AccountCr { get; set; }

    public int LoanRecId { get; set; }

    public virtual LoanRec LoanRec { get; set; } = null!;
}
