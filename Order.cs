using System;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }  // CID
    public string StockSymbol { get; set; }  // Σύμβολο μετοχής, π.χ. "NBG"
    public string StockISIN { get; set; }  // πχ για NBG: GRS003003035
    public int Quantity { get; set; }  // Ποσότητα μετοχών
    public decimal Price { get; set; }  // Τιμή ανά μετοχή
    public OrderType Type { get; set; }  // Τύπος εντολής
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	
    public bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(StockSymbol))
            return false;
        if (string.IsNullOrWhiteSpace(StockISIN))
            return false;
        if (Quantity <= 0)
            return false;
        if (Price <= 0)
            return false;

        return true;
    }
}
