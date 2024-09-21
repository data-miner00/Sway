﻿namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Dtos;
using Sway.Core.Models;
using Sway.Core.Repositories;

[Route("Profile/[controller]/[action]")]
public class PaymentMethodController : Controller
{
    private readonly IPaymentMethodRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public PaymentMethodController(IPaymentMethodRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var paymentMethods = await this.repository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(paymentMethods);
    }

    [Route("{id:guid}")]
    public async Task<IActionResult> Index(Guid id)
    {
        var paymentMethod = await this.repository.GetByIdAsync(id.ToString(), this.CancellationToken);

        return this.Ok(paymentMethod);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentMethodRequest request)
    {
        if (!Guid.TryParse(Constants.TestUserId, out var userId))
        {
            return this.BadRequest("The TestUserId is not a Guid.");
        }

        var entity = new PaymentMethod
        {
            Type = request.PaymentType,
            Provider = request.Provider,
            CVV = request.CVV,
            ExpiryDate = request.ExpiryDate,
            CardholderName = request.CardholderName,
            CardIssuingBank = request.CardIssuingBank,
            CardNumber = request.CardNumber,
            CardIssuingCountry = request.CardIssuingCountry,
            Currency = request.Currency,
            WalletAddress = request.WalletAddress,
            Balance = request.Balance,
            UserId = userId,
        };

        await this.repository.CreateAsync(entity, this.CancellationToken);

        return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdatePaymentMethodRequest request)
    {
        var entity = new PaymentMethod
        {
            Id = request.Id,
            Type = request.PaymentType,
            Provider = request.Provider,
            CVV = request.CVV,
            ExpiryDate = request.ExpiryDate,
            CardholderName = request.CardholderName,
            CardIssuingBank = request.CardIssuingBank,
            CardNumber = request.CardNumber,
            CardIssuingCountry = request.CardIssuingCountry,
            Currency = request.Currency,
            Balance = request.Balance,
            WalletAddress = request.WalletAddress,
        };

        await this.repository.UpdateAsync(entity, this.CancellationToken);

        return this.Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await this.repository.DeleteByIdAsync(id.ToString(), this.CancellationToken);

        return this.Ok();
    }
}
