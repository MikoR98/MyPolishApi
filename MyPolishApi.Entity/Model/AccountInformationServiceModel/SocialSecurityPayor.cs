

using MyPolishApi.Entity.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class SocialSecurityPayor 
    {
        
        
        
        
       

        
        
        
        
        [DataMember(Name="additionalPayorIdType", EmitDefaultValue=false)]
        public AdditionalPayorIdTypeEnum? AdditionalPayorIdType { get; set; }
        
        
        
        
        
        
       
        
        
        
        
        [DataMember(Name="nip", EmitDefaultValue=false)]
        public string Nip { get; set; }

        
        
        
        
        [DataMember(Name="additionalPayorId", EmitDefaultValue=false)]
        public string AdditionalPayorId { get; set; }


        
        
        
        
       
        
        
        
        
        
        
        
        
      

        
        
        
        
        
       
    }

}
