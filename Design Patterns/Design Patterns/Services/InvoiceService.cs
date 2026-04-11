using System;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;

namespace Design_Patterns.Services;

/// <summary>
/// Implements invoice service for generating order invoices.
/// This class handles the creation of billing documents for completed orders.
/// </summary>
public class InvoiceService : IInvoiceService
{
    /// <summary>
    /// Generates an invoice for the order.
    /// </summary>
    /// <param name="order">The order details to include in the generated invoice.</param>
    public void Generate(Order order)
    {
        // SOLID - S: Single responsibility - only handles invoice generation
        // In real implementation, this would create PDF or other invoice format
        Console.WriteLine("Invoice generated");
    }
}