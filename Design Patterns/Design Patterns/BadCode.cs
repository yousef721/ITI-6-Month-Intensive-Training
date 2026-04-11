// This file contains the "bad" implementation before applying design patterns and SOLID principles.
// It demonstrates multiple anti-patterns and SOLID violations:
//
// SOLID Violations:
// - S (Single Responsibility): OrderService handles discounts, persistence, notifications, AND invoices
// - O (Open/Closed): Adding new discount types requires modifying existing code
// - L (Liskov Substitution): No abstractions, can't substitute implementations
// - I (Interface Segregation): No interfaces, tight coupling to concrete classes
// - D (Dependency Inversion): Depends on concrete classes, not abstractions
//
// Design Pattern Issues:
// - No Strategy pattern: Discount logic hardcoded in ProcessOrder
// - No Repository pattern: Data access mixed with business logic
// - No Dependency Injection: Hardcoded dependencies
// - Tight Coupling: Classes directly instantiate their dependencies
//
// This code is commented out to prevent compilation - it's for educational purposes only.
// Compare this with the refactored code in other files to see the improvements.
// ========================================================================================
// using System;
// using System.Collections.Generic;

// public class Order
// {
//     public int Id { get; set; }
//     public double TotalPrice { get; set; }
//     public string? CustomerEmail { get; set; }
// }

// public class OrderService
// {
//     // VIOLATION: No dependency injection, tight coupling
//     private HighDiscount highDiscount;
//     private OrderRepository orderRepository;
//     private List<INotificationService> notificationServices;
//     private InvoiceService invoiceService;

//     public OrderService(HighDiscount highDiscount, OrderRepository orderRepository, List<INotificationService> notificationServices, InvoiceService invoiceService)
//     {
//         this.highDiscount = highDiscount;
//         this.orderRepository = orderRepository;
//         this.notificationServices = notificationServices;
//         this.invoiceService = invoiceService;
//     }

//     public void ProcessOrder(Order order)
//     {
//         // VIOLATION: Business logic mixed with discount logic (no Strategy pattern)
//         if (order.TotalPrice > 1000)
//         {
//             order.TotalPrice *= 0.9;
//         }

//         // VIOLATION: Data access logic mixed with business logic (no Repository pattern)
//         Console.WriteLine("Saving order to DB...");

//         // VIOLATION: Notification logic hardcoded (no Strategy pattern)
//         Console.WriteLine($"Sending email to {order.CustomerEmail}");

//         // VIOLATION: Invoice logic mixed in (violates Single Responsibility)
//         Console.WriteLine("Generating invoice PDF...");

//         Console.WriteLine("Order processed successfully");
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         var order = new Order
//         {
//             Id = 1,
//             TotalPrice = 1200,
//             CustomerEmail = "test@mail.com"
//         };

//         // VIOLATION: Tight coupling - can't easily change implementations
//         var service = new OrderService();
//         service.ProcessOrder(order);
//     }
// }