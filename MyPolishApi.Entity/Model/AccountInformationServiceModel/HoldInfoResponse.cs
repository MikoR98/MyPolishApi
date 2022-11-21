

using MyPolishApi.Entity.Model.AccountInformationServiceModel;
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
    public partial class HoldInfoResponse 
    {
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        [DataMember(Name="responseHeader", EmitDefaultValue=false)]
        public ResponseHeader ResponseHeader { get; set; }

        
        
        
        [DataMember(Name="holds", EmitDefaultValue=false)]
        public List<HoldInfo> Holds { get; set; }

        
        
        
        [DataMember(Name="pageInfo", EmitDefaultValue=false)]
        public PageInfo PageInfo { get; set; }

        
        
        
        
       
  
        
        
        
        
        
        
        
        
        
        
       
        
        
        
        
        
       

        
        
        
        
       

        
        
        
        
        
        
    }

}
