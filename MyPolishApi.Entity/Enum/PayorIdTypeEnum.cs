using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PayorIdTypeEnum
    {
        [EnumMember(Value = "N")]
        N = 1,

        [EnumMember(Value = "P")]
        P = 2,

        [EnumMember(Value = "R")]
        R = 3,

        [EnumMember(Value = "1")]
        _1 = 4,

        [EnumMember(Value = "2")]
        _2 = 5,

        [EnumMember(Value = "3")]
        _3 = 6
    }
}
