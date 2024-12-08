namespace FinanceController.Domain.Entities;
public class Privilege : Base
{
    public string Name { get; set; }
    public Guid? DomainId { get; set; }
    public Domain Domain { get; set; }

    public IList<User> Users { get; private set; } = new List<User>();

    public Privilege(string name, Guid? domainId)
    {
        Name = name;
        DomainId = domainId;
    }
}
