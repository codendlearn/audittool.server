using System;
using Newtonsoft.Json;

namespace AuditTool.Models
{
    public class BaseModel
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}