using FinanceController.Domain.Commands.Contracts;

namespace FinanceController.Domain.Commands.Bills
{
    public class CreateBillTypeCommand : ICommand
    {
        public string Type { get; set; }

        public CreateBillTypeCommand(string type)
        {
            Type = type;
        }
    }
}
