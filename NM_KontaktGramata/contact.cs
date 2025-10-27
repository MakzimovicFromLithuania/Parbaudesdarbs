using System;

namespace NM_KontaktGramata
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";

        public override string ToString() => $"{Name} ({Phone})";

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Vārds ir obligāts.");
            if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
                throw new Exception("E-pasta formāts nav pareizs.");
        }
    }
}
