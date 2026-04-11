using System;
using Design_Patterns.Models;

namespace Design_Patterns.Interfaces;

/// <summary>
/// Defines a service for sending notifications about orders.
/// Implementations can send different types of notifications (email, SMS, etc.)
/// following the Strategy or Observer pattern.
/// </summary>
public interface INotificationService
{
    /// <summary>
    /// Sends a notification for the given order.
    /// </summary>
    /// <param name="order">The order details to include in the notification.</param>
    void Send(Order order);
}

