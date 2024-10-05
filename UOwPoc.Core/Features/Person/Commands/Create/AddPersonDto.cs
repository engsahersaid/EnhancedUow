namespace UOwPoc.Core.Features.Person.Commands.Create
{
    public class AddPersonDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public int Age { get; set; }
        public IList<AddAddressDto>? Addresses { get; init; }
    }
}