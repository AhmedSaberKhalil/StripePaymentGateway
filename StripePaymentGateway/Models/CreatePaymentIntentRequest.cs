namespace StripePaymentGateway.Models
{
    public class CreatePaymentIntentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
