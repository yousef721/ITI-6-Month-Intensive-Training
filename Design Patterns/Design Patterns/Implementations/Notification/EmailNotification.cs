using System;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;

namespace Design_Patterns.Implementations.Notification;

/// <summary>
/// Implements email notification service for sending order confirmations via email.
/// This class demonstrates how different notification strategies can be implemented.
/// </summary>
public class EmailNotification : INotificationService
{
    /// <summary>
    /// Sends an email notification to the customer's email address.
    /// </summary>
    /// <param name="order">The order details to include in the email notification.</param>
    public void Send(Order order)
    {
        // Strategy Pattern: Concrete notification implementation
        // SOLID - S: Single responsibility - only handles email notifications
        // SOLID - I: Implements only the notification interface, no extra dependencies
        Console.WriteLine($"Email sent to {order.CustomerEmail}");
    }
}