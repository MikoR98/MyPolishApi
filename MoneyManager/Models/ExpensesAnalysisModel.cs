using MyPolishApi.Entity.Enum;
using MyPolishApi.Entity.Model.AccountInformationServiceModel;

namespace MoneyManager.Models
{
    public class ExpensesAnalysisModel
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string TradeDate { get; set; }

        public TransactionCategoryEnum TransactionCategory { get; set; }

        public string TransactionStatus { get; set; }

        public SenderRecipient Sender { get; set; }

        public SenderRecipient Recipient { get; set; }

        public decimal PostTransactionBalance { get; set; }

        public string ExpenseCategory { get; set; }
    }
}
