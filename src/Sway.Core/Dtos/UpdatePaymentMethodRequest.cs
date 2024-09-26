namespace Sway.Core.Dtos;

using Sway.Core.Models;
using System;

public class UpdatePaymentMethodRequest
{
    public Guid Id { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Provider { get; set; }

    public int? CVV { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? CardholderName { get; set; }

    public string? CardNumber { get; set; }

    public string? WalletAddress { get; set; }

    public string? CardIssuingCountry { get; set; }

    public string? CardIssuingBank { get; set; }

    public string Currency { get; set; }

    public decimal? Balance { get; set; }

    public bool IsDefault { get; set; }
}
