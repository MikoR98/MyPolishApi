using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public partial class SenderRecipient 
    {
        [Key]
        [DataMember(Name="accountNumber", EmitDefaultValue=false)]
        public string AccountNumber { get; set; }

        [DataMember(Name="accountMassPayment", EmitDefaultValue=false)]
        public string AccountMassPayment { get; set; }

        [DataMember(Name = "bicOrSwift", EmitDefaultValue = false)]
        public string BicOrSwift { get; set; }

        [DataMember(Name = "nameAddressId", EmitDefaultValue = false)]
        public string NameAddressId { get; set; }

        [DataMember(Name="bank", EmitDefaultValue=false)]
        public virtual Bank Bank { get; set; }

        [DataMember(Name="nameAddress", EmitDefaultValue=false)]
        public virtual NameAddress NameAddress { get; set; }

        [DataMember(Name = "transactionInfoSender", EmitDefaultValue = false)]
        public virtual TransactionInfo TransactionInfoSender { get; set; }

        [DataMember(Name = "transactionInfoRecipient ", EmitDefaultValue = false)]
        public virtual TransactionInfo TransactionInfoRecipient { get; set; }

        [DataMember(Name = "transactionPendingInfoSender", EmitDefaultValue = false)]
        public virtual TransactionPendingInfo TransactionPendingInfoSender { get; set; }

        [DataMember(Name = "transactionPendingInfoRecipient ", EmitDefaultValue = false)]
        public virtual TransactionPendingInfo TransactionPendingInfoRecipient { get; set; }

        [DataMember(Name = "transactionRejectedInfoSender", EmitDefaultValue = false)]
        public virtual TransactionRejectedInfo TransactionRejectedInfoSender { get; set; }

        [DataMember(Name = "transactionRejectedInfoRecipient ", EmitDefaultValue = false)]
        public virtual TransactionRejectedInfo TransactionRejectedInfoRecipient { get; set; }

        [DataMember(Name = "transactionCancelledInfoSender", EmitDefaultValue = false)]
        public virtual TransactionCancelledInfo TransactionCancelledInfoSender { get; set; }

        [DataMember(Name = "transactionCancelledInfoRecipient ", EmitDefaultValue = false)]
        public virtual TransactionCancelledInfo TransactionCancelledInfoRecipient { get; set; }

        [DataMember(Name = "transactionScheduledInfoSender", EmitDefaultValue = false)]
        public virtual TransactionScheduledInfo TransactionScheduledInfoSender { get; set; }

        [DataMember(Name = "transactionScheduledInfoRecipient ", EmitDefaultValue = false)]
        public virtual TransactionScheduledInfo TransactionScheduledInfoRecipient { get; set; }
    }
}
