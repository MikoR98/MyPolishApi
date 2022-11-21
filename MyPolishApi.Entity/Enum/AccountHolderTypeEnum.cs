using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountHolderTypeEnum
    {
        [EnumMember(Value = "individual")]
        Individual = 1,

        [EnumMember(Value = "corporation")]
        Corporation = 2
    }
}
