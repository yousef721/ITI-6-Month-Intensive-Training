using System;
using Design_Patterns.Models;

namespace Design_Patterns.Interfaces;

/// <summary>
/// Defines a service for generating invoices for orders.
/// This interface allows different invoice generation strategies.
/// </summary>
public interface IInvoiceService
{
    /// <summary>
    /// Generates an invoice for the given order.
    /// </summary>
    /// <param name="order">The order details to include in the invoice.</param>
    void Generate(Order order);
}
