using System;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;

namespace Design_Patterns.Services;

/// <summary>
/// Orchestrates the complete order processing workflow.
/// This class implements the Facade pattern, providing a simplified interface
/// to coordinate multiple subsystems: discounting, persistence, notifications, and invoicing.
/// All dependencies are injected via constructor for testability and loose coupling.
/// </summary>
public class OrderService
{
    /// <summary>
    /// The discount strategy to apply to order totals.
    /// </summary>
    private readonly IDiscountStrategy _discount;

    /// <summary>
    /// The repository for persisting order data.
    /// </summary>
    private readonly IOrderRepository _repo;

    /// <summary>
    /// Collection of notification services to send order confirmations.
    /// </summary>
    private readonly IEnumerable<INotificationService> _notifications;

    /// <summary>
    /// The service for generating order invoices.
    /// </summary>
    private readonly IInvoiceService _invoice;

    /// <summary>
    /// Initializes a new instance of the OrderService with required dependencies.
    /// </summary>
    /// <param name="discount">The discount strategy implementation to use.</param>
    /// <param name="repo">The order repository for data persistence.</param>
    /// <param name="notifications">Collection of notification services for order confirmations.</param>
    /// <param name="invoice">The invoice service for generating billing documents.</param>
    public OrderService(
        IDiscountStrategy discount,
        IOrderRepository repo,
        IEnumerable<INotificationService> notifications,
        IInvoiceService invoice)
    {
        // Dependency Injection: All dependencies injected via constructor
        // SOLID - D: Depend on abstractions (interfaces), not concrete classes
        // This enables loose coupling, testability, and easy substitution of implementations
        _discount = discount;
        _repo = repo;
        _notifications = notifications;
        _invoice = invoice;
    }

    /// <summary>
    /// Processes an order by applying discounts, saving to repository,
    /// sending notifications, and generating an invoice.
    /// </summary>
    /// <param name="order">The order entity to process.</param>
    public void Process(Order order)
    {
        // Strategy Pattern: Apply discount based on selected strategy (HighDiscount/NoDiscount)
        // SOLID - O: Open for extension (new discount strategies), Closed for modification
        order.TotalPrice = _discount.ApplyDiscount(order.TotalPrice);

        // Repository Pattern: Abstract data persistence, decouples business logic from storage
        // SOLID - D: Depend on abstraction (IOrderRepository), not concrete implementation
        _repo.Save(order);

        // Observer-like Pattern: Multiple notification services can be registered and executed
        // SOLID - I: Interface segregation - each notification implements only INotificationService
        foreach (var n in _notifications)
            n.Send(order);

        // Facade Pattern: This method simplifies complex interactions between multiple subsystems
        // SOLID - S: Single responsibility - this class orchestrates order processing workflow
        _invoice.Generate(order);
    }
}
