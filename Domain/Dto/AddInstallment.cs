
namespace Domain.Dto;
public class AddInstallment
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Installments { get; set; }
    public int Percentage { get; set; }

}