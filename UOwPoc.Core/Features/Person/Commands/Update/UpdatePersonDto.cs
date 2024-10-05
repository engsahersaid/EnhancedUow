namespace UOwPoc.Core.Features.Person.Commands.Update
{
    public class UpdatePersonDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public int Age { get; set; }
        public IList<UpdateAddressDto>? Addresses { get; init; }
    }
}