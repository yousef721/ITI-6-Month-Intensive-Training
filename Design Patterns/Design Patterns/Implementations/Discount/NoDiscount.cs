using System;
using Design_Patterns.Interfaces;

namespace Design_Patterns.Implementations.Discount;

/// <summary>
/// Implements a no-discount strategy that returns the original total unchanged.
/// This class provides a default or null-object implementation of the discount strategy.
/// </summary>
public class NoDiscount : IDiscountStrategy
{
    /// <summary>
    /// Returns the total unchanged, applying no discount.
    /// </summary>
    /// <param name="total">The original total price.</param>
    /// <returns>The same total price without any discount applied.</returns>
    public double ApplyDiscount(double total) => total; // Strategy Pattern: Null-object pattern for no discount
}