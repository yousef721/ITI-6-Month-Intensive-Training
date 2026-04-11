using System;

namespace Design_Patterns.Interfaces;

/// <summary>
/// Defines a strategy for applying discounts to order totals.
/// This interface allows different discount algorithms to be implemented
/// and selected at runtime, following the Strategy design pattern.
/// </summary>
public interface IDiscountStrategy
{
    /// <summary>
    /// Applies the discount to the given total amount.
    /// </summary>
    /// <param name="total">The original total price before discount.</param>
    /// <returns>The discounted total price.</returns>
    double ApplyDiscount(double total);
}