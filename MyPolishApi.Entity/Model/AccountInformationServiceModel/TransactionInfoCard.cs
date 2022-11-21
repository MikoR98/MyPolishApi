

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{
    
    
    
    [DataContract]
    public partial class TransactionInfoCard
    { 
        
        
        
        
       
        
        
        
        
        
        [DataMember(Name="cardHolder", EmitDefaultValue=false)]
        public string CardHolder { get; set; }

        
        
        
        
        [DataMember(Name="cardNumber", EmitDefaultValue=false)]
        public string CardNumber { get; set; }

        
        
        
        
    
  
        
        
        
        
     

        
        
        
        
        
      
        
        
    
        
        
        
        
    }

}
