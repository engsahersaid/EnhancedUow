namespace UOwPoc.Core.Features.Person.Commands.Create
{
    public class AddAddressDto
    {
        public string Country { get; init; }
        public string POBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
    }
}