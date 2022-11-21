

using MyPolishApi.Entity.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class Payor 
    {
        
        
        
        
        

        
        
        
        
        [DataMember(Name="payorIdType", EmitDefaultValue=false)]
        public PayorIdTypeEnum PayorIdType { get; set; }
        
        
        
        [JsonConstructorAttribute]
        protected Payor() { }
        
        
        
        
        
        
        
        
        
        
        [DataMember(Name="payorId", EmitDefaultValue=false)]
        public string PayorId { get; set; }


        
        
        
        
       
  
        
        
        
       
        
        
        
        
        
       
        
        
        
        
        
        

        
        
        
       

        
        
        
        
        
       
    }

}
