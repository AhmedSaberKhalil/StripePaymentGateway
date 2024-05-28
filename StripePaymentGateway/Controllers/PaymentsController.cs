﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripePaymentGateway.Models;
using StripePaymentGateway.StripeService;

namespace StripePaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentRequest request)
        {
            var paymentIntent = await _paymentService.CreatePaymentIntent(request.Amount, request.Currency);
            return Ok(new { clientSecret = paymentIntent.ClientSecret, paymentIntentId = paymentIntent.Id });

        }

        [HttpPost("confirm-payment-intent")]
        public async Task<IActionResult> ConfirmPaymentIntent([FromBody] ConfirmPaymentIntentRequest request)
        {
            var paymentIntent = await _paymentService.ConfirmPaymentIntent(request.PaymentIntentId, request.PaymentMethodId);
            return Ok(new { success = paymentIntent.Status == "succeeded" });
        }
    }
}
