

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class TransactionInfoTax
    { 
        
        
        
       
        
        
        
        
        
        
        
       
        
        
        
        [DataMember(Name="payerInfo", EmitDefaultValue=false)]
        public Payor PayerInfo { get; set; }

        
        
        
        
        [DataMember(Name="formCode", EmitDefaultValue=false)]
        public string FormCode { get; set; }

        
        
        
        
        [DataMember(Name="periodId", EmitDefaultValue=false)]
        public string PeriodId { get; set; }

        
        
        
        
        [DataMember(Name="periodType", EmitDefaultValue=false)]
        public string PeriodType { get; set; }

        
        
        
        
        [DataMember(Name="year", EmitDefaultValue=false)]
        public int? Year { get; set; }

        
        
        
        
        [DataMember(Name="obligationId", EmitDefaultValue=false)]
        public string ObligationId { get; set; }

        
        
        
        
       
        
        
        
     
        
        
     
        
        
       
    }

}
