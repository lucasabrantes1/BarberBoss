namespace BarberBoss.Communication.Responses;
public class ResponseShortInvoicingJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
