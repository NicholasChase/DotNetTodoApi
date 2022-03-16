using System.Text.Json.Serialization;
using todoDotNet6.Repo;

namespace todoDotNet6
{
    
    public class Todo : IEntity<Guid>
    {   
        [JsonPropertyName("uuid")]
        public Guid Id { get; set; }

        [JsonPropertyName("todo")]
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Boolean Completed { get; set; }
    }
}