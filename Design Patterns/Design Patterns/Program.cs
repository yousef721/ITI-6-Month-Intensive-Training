using Design_Patterns.Implementations.Notification;
using Design_Patterns.Implementations.Repository;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;
using Design_Patterns.Services;
using Design_Patterns.Implementations;

namespace Design_Patterns;

/// <summary>
/// Main program class demonstrating the design patterns implementation.
/// This class shows how to compose and use the various services with dependency injection.
/// </summary>
class Program
{
    /// <summary>
    /// Entry point of the application. Creates an order and processes it using the OrderService.
    /// Demonstrates the composition of different design pattern implementations.
    /// </summary>
    /// <param name="args">Command line arguments (not used in this demo).</param>
    static void Main(string[] args)
    {
        // Create sample order data
        var order = new Order
        {
            Id = 1,
            TotalPrice = 1200,
            CustomerEmail = "test@mail.com"
        };

        // Dependency Injection: Compose the OrderService with concrete implementations
        // This demonstrates how different strategies can be plugged in at runtime
        // SOLID - D: High-level module (Program) depends on abstractions through interfaces
        var service = new OrderService(
            new HighDiscount(),        // Strategy: High-value discount strategy
            new OrderRepository(),     // Repository: Database persistence
            new List<INotificationService>
            {
                new EmailNotification(), // Strategy: Email notification
                new SmsNotification()    // Strategy: SMS notification (multiple strategies)
            },
            new InvoiceService()        // Service: Invoice generation
        );

        // Facade Pattern: Single method call handles complex workflow
        service.Process(order);
    }
}