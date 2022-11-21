using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionCategoryEnum
    {
        [EnumMember(Value = "CREDIT")]
        CREDIT = 1,

        [EnumMember(Value = "DEBIT")]
        DEBIT = 2
    }
}
