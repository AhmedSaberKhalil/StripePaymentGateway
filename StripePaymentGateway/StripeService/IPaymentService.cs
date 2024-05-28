﻿using Stripe;

namespace StripePaymentGateway.StripeService
{
    public interface IPaymentService
    {
        public Task<PaymentIntent> CreatePaymentIntent(decimal amount, string currency);
        public Task<PaymentIntent> ConfirmPaymentIntent(string paymentIntentId, string paymentMethodId);
    }
}
