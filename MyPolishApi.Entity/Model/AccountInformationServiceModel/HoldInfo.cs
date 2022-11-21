

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class HoldInfo 
    {
        
        
        
        
        
        
        
      
        public DateTime? HoldExpirationDate { get; set; }

        
        
        
        [DataMember(Name="initiator", EmitDefaultValue=false)]
        public NameAddress Initiator { get; set; }

        
        
        
        [DataMember(Name="sender", EmitDefaultValue=false)]
        public SenderRecipient Sender { get; set; }

        
        
        
        [DataMember(Name="recipient", EmitDefaultValue=false)]
        public SenderRecipient Recipient { get; set; }

        
        
        
        
       
  
        
        
        
        
      
        
        
        
        
     
        
        
        
       
        
        
        
        
        
       
    }

}
