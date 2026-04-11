using System;
using Design_Patterns.Models;

namespace Design_Patterns.Interfaces;

/// <summary>
/// Defines a repository for persisting order data.
/// This interface abstracts the data access layer, allowing different storage implementations.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Saves the order to the data store.
    /// </summary>
    /// <param name="order">The order entity to persist.</param>
    void Save(Order order);
}