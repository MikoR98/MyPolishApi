using MyPolishApi.Entity.Model.AccountInformationServiceModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class NameAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "accountInfo", EmitDefaultValue = false)]
        public virtual AccountInfo AccountInfo { get; set; }

        [DataMember(Name = "bankAccountInfo", EmitDefaultValue = false)]
        public virtual BankAccountInfo BankAccountInfo { get; set; }

        [DataMember(Name = "senderRecipient", EmitDefaultValue = false)]
        public virtual SenderRecipient SenderRecipient { get; set; }

        [DataMember(Name = "bank", EmitDefaultValue = false)]
        public virtual Bank Bank { get; set; }

        [DataMember(Name = "transactionInfo", EmitDefaultValue = false)]
        public virtual TransactionInfo TransactionInfo { get; set; }

        [DataMember(Name = "transactionPendingInfo", EmitDefaultValue = false)]
        public virtual TransactionPendingInfo TransactionPendingInfo { get; set; }

        [DataMember(Name = "transactionRejectedInfo", EmitDefaultValue = false)]
        public virtual TransactionRejectedInfo TransactionRejectedInfo { get; set; }

        [DataMember(Name = "transactionCancelledInfo", EmitDefaultValue = false)]
        public virtual TransactionCancelledInfo TransactionCancelledInfo { get; set; }

        [DataMember(Name = "transactionScheduledInfo", EmitDefaultValue = false)]
        public virtual TransactionScheduledInfo TransactionScheduledInfo { get; set; }
    }
}
