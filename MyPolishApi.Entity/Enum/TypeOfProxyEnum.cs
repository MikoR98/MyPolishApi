using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfProxyEnum
    {
        [EnumMember(Value = "General")]
        General = 1,

        [EnumMember(Value = "Special")]
        Special = 2,

        [EnumMember(Value = "Administrator")]
        Administrator = 3,

        [EnumMember(Value = "User")]
        User = 4
    }
}
