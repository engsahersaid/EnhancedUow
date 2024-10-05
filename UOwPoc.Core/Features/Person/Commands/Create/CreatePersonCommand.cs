using MediatR;

namespace UOwPoc.Core.Features.Person.Commands.Create
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public AddPersonDto Person { get; }

        public CreatePersonCommand(AddPersonDto person)
        {
            Person = person;
        }
    }
}