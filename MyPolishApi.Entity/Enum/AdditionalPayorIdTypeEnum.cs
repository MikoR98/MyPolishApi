using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
        public enum AdditionalPayorIdTypeEnum
        {
            [EnumMember(Value = "P")]
            P = 1,

            [EnumMember(Value = "R")]
            R = 2,

            [EnumMember(Value = "1")]
            _1 = 3,

            [EnumMember(Value = "2")]
            _2 = 4
        }
}
