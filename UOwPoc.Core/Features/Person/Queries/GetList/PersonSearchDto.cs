namespace UOwPoc.Core.Features.Person.Queries.GetList
{
    public class PersonSearchDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NationalityId { get; set; }
    }
}