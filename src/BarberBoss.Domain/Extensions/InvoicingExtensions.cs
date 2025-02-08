using BarberBoss.Domain.Enums;
using BarberBoss.Domain.Reports;

namespace BarberBoss.Domain.Extensions;
public static class InvoicingExtensions
{
    public static string PaymentTypeToStringExtension(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportPaymentTypeText.CASH,
            PaymentType.CreditCard => ResourceReportPaymentTypeText.CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportPaymentTypeText.DEBIT_CARD,
            PaymentType.EletronicTransfer => ResourceReportPaymentTypeText.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
