namespace UOwPoc.Core.Features.Person.Commands.Update
{
    public class UpdateAddressDto
    {
        public Guid Id { get; set; }
        public string Country { get; init; }
        public string POBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
    }
}