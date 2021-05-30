using System;

namespace AuditTool.Models
{

    public class Engagement : BaseModel
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string Category { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? RollOffDate { get; set; }
    }
}