using System;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;

namespace Design_Patterns.Implementations;

/// <summary>
/// Implements SMS notification service for sending order confirmations via text message.
/// This class shows how multiple notification types can coexist.
/// </summary>
public class SmsNotification : INotificationService
{
    /// <summary>
    /// Sends an SMS notification to confirm the order.
    /// </summary>
    /// <param name="order">The order details (currently not used in SMS implementation).</param>
    public void Send(Order order)
    {
        // Strategy Pattern: Alternative notification implementation
        // SOLID - L: Can be used interchangeably with EmailNotification
        // SOLID - S: Focused only on SMS sending logic
        Console.WriteLine("SMS sent");
    }
}