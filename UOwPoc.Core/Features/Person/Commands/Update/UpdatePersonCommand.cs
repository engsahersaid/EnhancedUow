using MediatR;

namespace UOwPoc.Core.Features.Person.Commands.Update
{
    public class UpdatePersonCommand : IRequest<Guid>
    {
        public UpdatePersonDto Person { get; }

        public UpdatePersonCommand(UpdatePersonDto person)
        {
            Person = person;
        }
    }
}