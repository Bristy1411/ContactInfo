﻿namespace ContactInfo.Dtos
{
    public class AddContactRequestDTO
    {
        public required string Name { get; set; }

        public string? Email { get; set; }
        public required string Number { get; set; }

        public bool Favoutite { get; set; }
    }
}
