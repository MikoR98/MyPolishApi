using MyPolishApi.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    public class AccountPsuRelation
    {
        [Key]
        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        [DataMember(Name = "typeOfRelation", EmitDefaultValue = false)]
        public TypeOfRelationEnum TypeOfRelation { get; set; }
        
        [DataMember(Name = "typeOfProxy", EmitDefaultValue = false)]
        public TypeOfProxyEnum? TypeOfProxy { get; set; }

        [DataMember(Name = "stake", EmitDefaultValue = false)]
        public int? Stake { get; set; }

        [DataMember(Name = "accountInfo", EmitDefaultValue = false)]
        public virtual AccountInfo AccountInfo { get; set; }
    }
}
