namespace StripePaymentGateway.Models
{
    public class ConfirmPaymentIntentRequest
    {
        public string PaymentIntentId { get; set; }
        public string PaymentMethodId { get; set; }


    }
}
