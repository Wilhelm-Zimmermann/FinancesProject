﻿namespace FinanceController.Domain.Entities;
public class User : Base
{
    public string? Name { get; set; }
    public string? Email { get; set; }

    public IList<Bill> Bills { get; private set; } = new List<Bill>();
    public IList<Privilege> Privileges { get; private set; } = new List<Privilege>();

    public User(string? name, string? email)
    {
        Name = name;
        Email = email;
    }

    public void AddBill(Bill bill)
    {
        Bills.Add(bill);
    }

    public void AddPrivilege(Privilege privilege)
    {
        Privileges.Add(privilege);
    }

    public void RemoveBill(Bill bill)
    {
        Bills.Remove(bill);
    }

    public void RemovePrivilege(Privilege privilege)
    {
        Privileges.Remove(privilege);
    }
}
