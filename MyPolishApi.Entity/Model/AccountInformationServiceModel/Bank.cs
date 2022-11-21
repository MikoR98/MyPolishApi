using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public partial class Bank 
    {
        [Key]
        [DataMember(Name="bicOrSwift", EmitDefaultValue=false)]
        public string BicOrSwift { get; set; }

        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        [DataMember(Name="countryCode", EmitDefaultValue=false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "nameAddressId", EmitDefaultValue = false)]
        public string NameAddressId { get; set; }

        [DataMember(Name="nameAddress", EmitDefaultValue=false)]
        public virtual NameAddress NameAddress { get; set; }

        [DataMember(Name = "senderRecipient", EmitDefaultValue = false)]
        public virtual SenderRecipient SenderRecipient { get; set; }
    }
}
