namespace FinanceController.Domain.Entities;
public class Domain : Base
{
    public string? Name { get; private set; }

    public IList<Privilege> Privileges { get; set; } = new List<Privilege>();

    public Domain(string? name)
    {
        Name = name;
    }
}
