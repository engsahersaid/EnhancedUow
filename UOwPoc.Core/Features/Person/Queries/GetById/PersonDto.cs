namespace UOwPoc.Core.Features.Person.Queries.GetById
{
    public class PersonDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public string NationalityName { get; init; }
        public int Age { get; set; }
        public IList<AddressDto>? Addresses { get; init; }
    }
}