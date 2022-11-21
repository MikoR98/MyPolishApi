using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MyPolishApi.Entity.Model.AccountInformationServiceModel
{
    [DataContract]
    public class UserAccount
    {
        [Key]
        public string Login { get; set; }

        [Required]
        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Name = "accountNumber", EmitDefaultValue = false)]
        public string AccountNumber { get; set; }

        [DataMember(Name = "ownerName", EmitDefaultValue = false)]
        public string OwnerName { get; set; }
    }
}
