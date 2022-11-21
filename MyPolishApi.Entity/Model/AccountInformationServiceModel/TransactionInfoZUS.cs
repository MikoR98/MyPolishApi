using System.Runtime.Serialization;

namespace IO.Swagger.Model
{
    [DataContract]
    public class TransactionInfoZUS 
    {
        [DataMember(Name="payerInfo", EmitDefaultValue=false)]
        public SocialSecurityPayor PayerInfo { get; set; }

        [DataMember(Name="contributionType", EmitDefaultValue=false)]
        public string ContributionType { get; set; }

        [DataMember(Name="contributionId", EmitDefaultValue=false)]
        public string ContributionId { get; set; }

        [DataMember(Name="contributionPeriod", EmitDefaultValue=false)]
        public string ContributionPeriod { get; set; }

        [DataMember(Name="paymentTypeId", EmitDefaultValue=false)]
        public string PaymentTypeId { get; set; }

        [DataMember(Name="obligationId", EmitDefaultValue=false)]
        public string ObligationId { get; set; }
    }
}
