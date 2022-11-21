using MyPolishApi.Entity.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class AccountInfo
    {
        [Key]
        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }
        
        [DataMember(Name = "nameAddressId", EmitDefaultValue = false)]
        public string NameAddressId { get; set; }

        [DataMember(Name = "accountType", EmitDefaultValue = false)]
        public string AccountType { get; set; }

        [DataMember(Name = "accountHolderType", EmitDefaultValue = false)]
        public AccountHolderTypeEnum AccountHolderType { get; set; }

        [DataMember(Name = "accountTypeName", EmitDefaultValue = false)]
        public string AccountTypeName { get; set; }

        [DataMember(Name = "accountNameClient", EmitDefaultValue = false)]
        public string AccountNameClient { get; set; }

        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        [DataMember(Name = "availableBalance", EmitDefaultValue = false)]
        public decimal AvailableBalance { get; set; }

        [DataMember(Name = "bookingBalance", EmitDefaultValue = false)]
        public decimal BookingBalance { get; set; }
        
        [DataMember(Name = "bicOrSwift", EmitDefaultValue = false)]
        public string BicOrSwift { get; set; }

        [DataMember(Name = "vatAccountNrb", EmitDefaultValue = false)]
        public string VatAccountNrb { get; set; }

        [DataMember(Name = "linkedAccountNumber", EmitDefaultValue = false)]
        public virtual List<LinkedAccount> LinkedAccount { get; set; }

        [DataMember(Name = "psuRelations", EmitDefaultValue = false)]
        public virtual AccountPsuRelation PsuRelations { get; set; }

        [DataMember(Name = "nameAddress", EmitDefaultValue = false)]
        public virtual NameAddress NameAddress { get; set; }

        [DataMember(Name = "dictionaryItem", EmitDefaultValue = false)]
        public virtual DictionaryItem DictionaryItem { get; set; }

        [DataMember(Name = "bankAccountInfo", EmitDefaultValue = false)]
        public virtual BankAccountInfo BankAccountInfo { get; set; }
    }
}
