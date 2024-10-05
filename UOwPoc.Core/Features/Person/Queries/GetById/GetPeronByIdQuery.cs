using MediatR;

namespace UOwPoc.Core.Features.Person.Queries.GetById
{
    public class GetPeronByIdQuery : IRequest<PersonDto>
    {
        public Guid Id { get; }

        public GetPeronByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}