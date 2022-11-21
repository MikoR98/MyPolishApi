using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public partial class BankAccountInfo
    {
        [Key]
        [DataMember(Name = "bicOrSwift", EmitDefaultValue = false)]
        public string BicOrSwift { get; set; }

        [DataMember(Name = "nameAddressId", EmitDefaultValue = false)]
        public string NameAddressId { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public virtual NameAddress NameAddress { get; set; }

        [DataMember(Name = "accountInfo", EmitDefaultValue = false)]
        public virtual AccountInfo AccountInfo { get; set; }
    }
}
