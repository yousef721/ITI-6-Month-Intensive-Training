using System;
using Design_Patterns.Interfaces;

namespace Design_Patterns.Implementations;

/// <summary>
/// Implements a high-value discount strategy that applies 10% off for orders over $1000.
/// This class demonstrates the Strategy pattern by encapsulating a specific discount algorithm.
/// </summary>
public class HighDiscount : IDiscountStrategy
{
    /// <summary>
    /// Applies a 10% discount if the total exceeds $1000, otherwise returns the original total.
    /// </summary>
    /// <param name="total">The original total price before discount.</param>
    /// <returns>The discounted price (10% off) if total > 1000, otherwise the original price.</returns>
    public double ApplyDiscount(double total)
    {
        // Strategy Pattern: Concrete implementation of discount algorithm
        // SOLID - S: Single responsibility - only handles high-value discount logic
        // SOLID - L: Can be substituted for any IDiscountStrategy implementation
        return total > 1000 ? total * 0.9 : total;
    }
}
