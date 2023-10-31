namespace TestHardCode.Models;

public class Product
{
    public Product( string nameProduct, Category? category, double price, StatusProduct statusProduct)
    {
        NameProduct = nameProduct;
        Category = category;
        Price = price;
        StatusProduct = statusProduct;
    }
    
    public Guid Id { get; set; }
    public string NameProduct { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public double Price { get; set; }
    public StatusProduct StatusProduct { get; set; }
    public Quantity Quantity { get; set; }
}