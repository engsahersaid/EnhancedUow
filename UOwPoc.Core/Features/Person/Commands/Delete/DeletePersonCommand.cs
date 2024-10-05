using MediatR;

namespace UOwPoc.Core.Features.Person.Commands.Delete
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public Guid PersonId { get; }

        public DeletePersonCommand(Guid personId)
        {
            PersonId = personId;
        }
    }
}