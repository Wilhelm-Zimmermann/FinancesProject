namespace FinanceController.Domain.Entities;
public class Privilege : Base
{
    public string Name { get; private set; }
    public Guid? DomainId { get; private set; }
    public Domain Domain { get; private set; }

    public IList<User> Users { get; private set; } = new List<User>();

    public Privilege(string name, Guid? domainId)
    {
        Name = name;
        DomainId = domainId;
    }
}
