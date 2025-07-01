using System.Collections.Generic;

public class Client
{
    public int Id { get; set; }

    public string Name { get; set; }  // Προσθήκη ονόματος πελάτη

    // Λίστα με τις εντολές που θέλει ο πελάτης
    public List<Order> Orders { get; set; } = new List<Order>();

    // Προσθήκη μιας εντολής
    public void AddOrder(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.ClientId != Id)
            throw new ArgumentException("Order ClientId does not match client Id.");

        Orders.Add(order);
    }
}
