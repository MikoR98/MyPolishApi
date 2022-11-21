using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfRelationEnum
    {
        [EnumMember(Value = "Owner")]
        Owner = 1,

        [EnumMember(Value = "Borrower")]
        Borrower = 2,

        [EnumMember(Value = "Guarantor")]
        Guarantor = 3,

        [EnumMember(Value = "ProxyOwner")]
        ProxyOwner = 4,

        [EnumMember(Value = "Beneficiary")]
        Beneficiary = 5,

        [EnumMember(Value = "Trustee")]
        Trustee = 6
    }
}
