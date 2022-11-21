using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class DictionaryItem
    {
        [Key]
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "accountInfo", EmitDefaultValue = false)]
        public virtual AccountInfo AccountInfo { get; set; }

        [DataMember(Name = "transactionInfo", EmitDefaultValue = false)]
        public virtual TransactionInfo TransactionInfo { get; set; }

        [DataMember(Name = "transactionCancelledInfo", EmitDefaultValue = false)]
        public virtual TransactionCancelledInfo TransactionCancelledInfo { get; set; }

        [DataMember(Name = "transactionScheduledInfo", EmitDefaultValue = false)]
        public virtual TransactionScheduledInfo TransactionScheduledInfo { get; set; }
    }
}
