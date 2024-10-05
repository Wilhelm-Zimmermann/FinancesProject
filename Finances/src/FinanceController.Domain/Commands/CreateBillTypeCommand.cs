using FinanceController.Domain.Commands.Contracts;

namespace FinanceController.Domain.Commands
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
