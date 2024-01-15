using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankManagement.Auth.ApiKey
{
    public class ApiKeyModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        public string Value { get; set; }

        [JsonIgnore]     
        public string UserID { get; set; }

        [JsonIgnore]
        public IdentityUser User { get; set; }
    }
}
