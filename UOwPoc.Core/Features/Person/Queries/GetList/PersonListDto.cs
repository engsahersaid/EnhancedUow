namespace UOwPoc.Core.Features.Person.Queries.GetList
{
    public class PersonListDto
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int NationalityId { get; init; }
        public string NationalityName { get; init; }
        public int Age { get; set; }
    }
}