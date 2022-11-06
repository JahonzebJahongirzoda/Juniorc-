namespace Domain.Dto;
public class GetProducts
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public IQueryable<int> Installment { get; set; }
}