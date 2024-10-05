using MediatR;
using UOwPoc.Core.Interfaces;

namespace UOwPoc.Core.Features.Person.Commands.Delete
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeletePersonCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _uow.QueryRepository<UOWPoc.Entities.Person>().GetById(request.PersonId);
            if (person == null)
                throw new Exception("Person not found");

            _uow.CommandRepository<UOWPoc.Entities.Person>().Delete(person);
            var res = await _uow.SaveChangesAsync(cancellationToken);
            return res > 0;
        }
    }
}