using System;

namespace Design_Patterns.Models;

/// <summary>
/// Represents an order entity with basic order information.
/// This class serves as the data model for order processing throughout the application.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the total price of the order before discounts.
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// Gets or sets the customer's email address for notifications.
    /// This field is optional and may be null.
    /// </summary>
    public string? CustomerEmail { get; set; }
}