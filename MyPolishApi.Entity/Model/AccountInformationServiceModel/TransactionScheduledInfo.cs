using MyPolishApi.Entity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class TransactionScheduledInfo : IItemInfoBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "itemId", EmitDefaultValue = false)]
        public string ItemId { get; set; }

        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public decimal Amount { get; set; }

        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "transactionType", EmitDefaultValue = false)]
        public string TransactionType { get; set; }

        [DataMember(Name = "tradeDate", EmitDefaultValue = false)]
        public DateTime? TradeDate { get; set; }

        [DataMember(Name = "mcc", EmitDefaultValue = false)]
        public string Mcc { get; set; }

        [DataMember(Name="transactionCategory", EmitDefaultValue=false)]
        public TransactionCategoryEnum TransactionCategory { get; set; }

        [DataMember(Name = "transactionStatus", EmitDefaultValue = false)]
        public string TransactionStatus { get; set; }

        [DataMember(Name = "initiator", EmitDefaultValue = false)]
        public string Initiator { get; set; }

        [DataMember(Name = "senderId", EmitDefaultValue = false)]
        public string SenderId { get; set; }

        [DataMember(Name = "recipientId", EmitDefaultValue = false)]
        public string RecipientId { get; set; }

        [DataMember(Name = "NameAddress", EmitDefaultValue = false)]
        public virtual NameAddress NameAddress { get; set; }

        [DataMember(Name = "dictionaryItem", EmitDefaultValue = false)]
        public virtual DictionaryItem DictionaryItem { get; set; }

        [DataMember(Name = "sender", EmitDefaultValue = false)]
        public virtual SenderRecipient Sender { get; set; }

        [DataMember(Name = "recipient", EmitDefaultValue = false)]
        public virtual SenderRecipient Recipient { get; set; }
    }
}
