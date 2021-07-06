namespace sampleApp.Models
{
    public record Result
    {
        public string Gender { get; init; }
        public Name Name { get; init; }
        public Location Location { get; init; }
         public string Email { get; init; }
        public Login Login { get; init; }
        public AgeDate Dob { get; init; }
        public AgeDate Registered { get; init; }
        public string Phone { get; init; }
        public string Cell { get; init; }
        public NameValue Id { get; init; }
        public Picture Picture { get; init; }
        public string Nat {get;init;}
    }
}
