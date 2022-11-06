namespace Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual List<CustomerPurchaces>? CustomerPurchaces { get; set; }

}