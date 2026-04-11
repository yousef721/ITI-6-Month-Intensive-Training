using System;
using Design_Patterns.Interfaces;
using Design_Patterns.Models;

namespace Design_Patterns.Implementations.Repository;

/// <summary>
/// Implements order repository using database storage.
/// This class demonstrates the Repository pattern for data persistence.
/// </summary>
public class OrderRepository : IOrderRepository
{
    /// <summary>
    /// Saves the order to the database.
    /// </summary>
    /// <param name="order">The order entity to persist in the database.</param>
    public void Save(Order order)
    {
        // Repository Pattern: Encapsulates data access logic
        // SOLID - S: Single responsibility - only handles order persistence
        // In real implementation, this would connect to actual database
        Console.WriteLine("Order saved to database");
    }
}
