using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class LinkedAccount
    {
        [Key]
        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        [Key]
        [DataMember(Name = "linkedAccountNumber", EmitDefaultValue = false)]
        public string LinkedAccountNumber { get; set; }

        [DataMember(Name = "accountInfo", EmitDefaultValue = false)]
        public virtual AccountInfo AccountInfo { get; set; }
    }
}
