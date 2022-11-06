namespace Domain.Entities;
public class Installment
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int Installments { get; set; }
    public int Percentage { get; set; }
    public virtual List<CustomerPurchaces>? CustomerPurchaces { get; set; }

}