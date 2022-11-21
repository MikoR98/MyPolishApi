using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    public interface IItemInfoBase
    {
        [Key]
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
    }
}
