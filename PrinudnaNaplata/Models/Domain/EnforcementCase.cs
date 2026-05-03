namespace PrinudnaNaplata.Domain;

public class EnforcementCase
{
    public long CaseId { get; set; }
    public int DebtorId { get; set; }
    public int ClientId { get; set; }
    public long? CourtId { get; set; }
    public long? SecondaryCourtId { get; set; }

    // Case identification numbers
    public string? CaseNumber { get; set; }
    public string? DecisionNumber { get; set; }
    public string? EnforcementNumber { get; set; }
    public string? CourtOrderNumber { get; set; }
    public string? MinorOffenseNumber { get; set; }
    public string? ExecutionNumber { get; set; }
    public string? RequestNumber { get; set; }
    public string? JoinedUnderNumber { get; set; }

    // Debt amounts
    public DateTime? DebtFrom { get; set; }
    public DateTime? DebtTo { get; set; }
    public decimal? DebtAmount { get; set; }
    public decimal? AttorneyFee { get; set; }
    public decimal? CourtFees { get; set; }
    public decimal? CurrentDebt { get; set; }
    public decimal? PaidAmount { get; set; }
    public decimal? DebtAmountAfterObjection { get; set; }
    public decimal? AttorneyFeeAfterObjection { get; set; }
    public decimal? CourtFeesAfterObjection { get; set; }
    public decimal? AdditionalAttorneyFee { get; set; }
    public decimal? SuccessPercentage { get; set; }
    public decimal? BillingPercentage { get; set; }

    // Key dates
    public DateTime? SubmittedOn { get; set; }
    public DateTime? IssuedOn { get; set; }
    public DateTime? ReceivedOn { get; set; }
    public DateTime? EnforcedOn { get; set; }
    public DateTime? PostponedUntil { get; set; }
    public DateTime? EnforcementDecisionDate { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? TrialDate { get; set; }
    public DateTime? FirstInstanceJudgmentDate { get; set; }
    public DateTime? SecondInstanceJudgmentDate { get; set; }
    public DateTime? MortgageDate { get; set; }
    public DateTime? MovablePropertyProposalSubmitted { get; set; }
    public DateTime? MovablePropertyProposalIssued { get; set; }
    public DateTime? ImmovablePropertyProposalSubmitted { get; set; }
    public DateTime? ImmovablePropertyProposalIssued { get; set; }

    // Status flags
    public bool IsPaid { get; set; }
    public bool IsSuspended { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsBilled { get; set; }
    public bool IsDeliveryConfirmed { get; set; }
    public bool IsSentToTreasury { get; set; }
    public bool IsPrincipalDebtPaid { get; set; }
    public bool HasObjection { get; set; }
    public bool IsObjectionUpheld { get; set; }
    public bool IsObjectionDismissed { get; set; }
    public bool IsObjectionRejected { get; set; }
    public bool IsInventoried { get; set; }
    public bool IsAppraised { get; set; }
    public bool IsSold { get; set; }
    public bool IsClosed { get; set; }
    public bool IsPostponed { get; set; }
    public bool IsRejected { get; set; }
    public bool IsTerminated { get; set; }
    public bool IsRefused { get; set; }
    public bool HasEnforcementDecision { get; set; }
    public bool HasSettlement { get; set; }
    public bool HasFirstInstanceJudgment { get; set; }
    public bool HasAppeal { get; set; }
    public bool HasSecondInstanceJudgment { get; set; }
    public bool HasJudgmentEnforcement { get; set; }
    public bool IsDeceased { get; set; }
    public bool HasNoMovableProperty { get; set; }
    public bool HasOrderAndInstruction { get; set; }
    public bool HasOrderNotCompliedWith { get; set; }
    public bool HasMovablePropertyProposal { get; set; }
    public bool HasImmovablePropertyProposal { get; set; }
    public bool AdditionalBilling { get; set; }
    public bool HasPublicAnnouncement { get; set; }
    public bool HasMortgage { get; set; }
    public bool BillAttorneyFee { get; set; }
    public bool BillWithVat { get; set; }
    public bool DoNotBill { get; set; }
    public bool Paid { get; set; }

    public string? Note { get; set; }
}
