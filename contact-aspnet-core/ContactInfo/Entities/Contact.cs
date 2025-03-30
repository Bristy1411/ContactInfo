using System.ComponentModel.DataAnnotations;

namespace ContactInfo.Entities

{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public string? Email { get; set; }
        public required string Number { get; set; }

        public bool Favorite { get; set; }
    }
}
