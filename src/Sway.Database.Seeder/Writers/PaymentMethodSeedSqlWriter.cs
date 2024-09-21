﻿namespace Sway.Database.Seeder.Writers;

using Sway.Common;
using Sway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SpNames = Sway.Common.StoredProcedureNames;

internal class PaymentMethodSeedSqlWriter : ISqlWriter<PaymentMethod>
{
    private readonly SqlFileNameBuilder fileNameBuilder;

    public PaymentMethodSeedSqlWriter(SqlFileNameBuilder fileNameBuilder)
    {
        this.fileNameBuilder = Guard.ThrowIfNull(fileNameBuilder);
    }

    public Task BulkWriteAsync(IEnumerable<PaymentMethod> entities, CancellationToken cancellationToken)
    {
        var sb = new StringBuilder();

        sb.AppendLine(@"-- ------------------------------------------------------------------------------");
        sb.AppendLine(@"-- <auto-generated>");
        sb.AppendLine(@$"-- This is the seeder file for {nameof(PaymentMethod)}.");
        sb.AppendLine(@$"-- Generated on {DateTime.Now.ToShortDateString()}.");
        sb.AppendLine(@"-- </auto-generated>");
        sb.AppendLine(@"-- ------------------------------------------------------------------------------");
        sb.AppendLine();

        sb.AppendLine(@"USE [Sway];");
        sb.AppendLine();
        sb.AppendLine();

        foreach (var method in entities)
        {
            var expiryDateString = method.ExpiryDate?.ToString("yyyy-MM-dd");

            sb.AppendLine(@$"EXEC {SpNames.AddPaymentMethod}");
            sb.AppendLine($"    @UserId = '{method.UserId}',");
            sb.AppendLine($"    @Provider = '{method.Provider}',");
            sb.AppendLine($"    @Type = '{method.Type}',");

            if (method.CVV != null)
            {
                sb.AppendLine($"    @CVV = {method.CVV},");
            }
            else
            {
                sb.AppendLine($"    @CVV = NULL,");
            }

            if (expiryDateString != null)
            {
                sb.AppendLine($"    @ExpiryDate = '{expiryDateString}',");
            }
            else
            {
                sb.AppendLine($"    @ExpiryDate = NULL,");
            }

            if (method.CardholderName != null)
            {
                sb.AppendLine($"    @CardholderName = '{method.CardholderName}',");
            }
            else
            {
                sb.AppendLine($"    @CardholderName = NULL,");
            }

            if (method.CardNumber != null)
            {
                sb.AppendLine($"    @CardNumber = '{method.CardNumber}',");
            }
            else
            {
                sb.AppendLine($"    @CardNumber = NULL,");
            }

            if (method.CardIssuingCountry != null)
            {
                sb.AppendLine($"    @CardIssuingCountry = '{method.CardIssuingCountry}',");
            }
            else
            {
                sb.AppendLine($"    @CardIssuingCountry = NULL,");
            }

            if (method.CardIssuingBank != null)
            {
                sb.AppendLine($"    @CardIssuingBank = '{method.CardIssuingBank}',");
            }
            else
            {
                sb.AppendLine($"    @CardIssuingBank = NULL,");
            }

            if (method.WalletAddress != null)
            {
                sb.AppendLine($"    @WalletAddress = '{method.WalletAddress}',");
            }
            else
            {
                sb.AppendLine($"    @WalletAddress = NULL,");
            }

            sb.AppendLine($"    @Currency = '{method.Currency}',");

            if (method.Balance != null)
            {
                sb.AppendLine($"    @Balance = '{method.Balance}';");
            }
            else
            {
                sb.AppendLine($"    @Balance = NULL;");
            }

            sb.AppendLine();
        }

        var scriptContent = sb.ToString();

        var fullFilePath = this.fileNameBuilder.Build();

        return File.WriteAllTextAsync(fullFilePath, scriptContent, cancellationToken);
    }
}
