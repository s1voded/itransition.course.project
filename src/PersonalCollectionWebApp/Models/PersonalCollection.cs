using Microsoft.Extensions.Hosting;
using PersonalCollectionWebApp.Data;
using System.Reflection.Metadata;

namespace PersonalCollectionWebApp.Models
{
    public class PersonalCollection
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Required foreign key property
        public ApplicationUser User { get; set; } = null!; // Required reference navigation to principal
        public Theme? Theme { get; set; }
        public ICollection<Item> Items { get; } = []; // Collection navigation containing dependents
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
