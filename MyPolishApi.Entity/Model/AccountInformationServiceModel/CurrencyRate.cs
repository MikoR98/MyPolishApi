

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class CurrencyRate 
    {
        
        
        
        
        
        
        
        
        
        
        
        [DataMember(Name="rate", EmitDefaultValue=false)]
        public double? Rate { get; set; }

        
        
        
        
        [DataMember(Name="fromCurrency", EmitDefaultValue=false)]
        public string FromCurrency { get; set; }

        
        
        
        
        [DataMember(Name="toCurrency", EmitDefaultValue=false)]
        public string ToCurrency { get; set; }

        
        
        
        
      
        
        
    
        
     
        
       

        
        
        
        
       
        
        
        
        
        
      
    }

}
