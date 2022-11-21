using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class AccountBaseInfo
    {
        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        [Key]
        public string AccountNumber { get; set; }

        [DataMember(Name = "accountTypeName", EmitDefaultValue = false)]
        public string AccountTypeName { get; set; }

        [DataMember(Name = "accountType", EmitDefaultValue = false)]
        public string AccountType { get; set; }

        //[DataMember(Name = "psuRelations", EmitDefaultValue = false)]
        //public List<AccountPsuRelation> PsuRelations { get; set; }

        public virtual AccountResponse AccountResponse { get; set; }

        public virtual DictionaryItem DictionaryItem { get; set; }
    }
}
