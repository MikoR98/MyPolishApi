

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Model
{



    [DataContract]
    public partial class TransactionInfoSp
    {
        
        
        
       
        
        
        
        
        
        
        
        
        
        
        [DataMember(Name="spInvoiceNumber", EmitDefaultValue=false)]
        public string SpInvoiceNumber { get; set; }

        
        
        
        
        [DataMember(Name="spTaxIdentificationNumber", EmitDefaultValue=false)]
        public string SpTaxIdentificationNumber { get; set; }

        
        
        
        
        [DataMember(Name="spTaxAmount", EmitDefaultValue=false)]
        public string SpTaxAmount { get; set; }

        
        
        
        
        [DataMember(Name="spDescription", EmitDefaultValue=false)]
        public string SpDescription { get; set; }

        
        
        
        
       
  
        
        
        
     
        
        
     
        
        
        
        
      
        
        
        
        
        
      
    }

}
