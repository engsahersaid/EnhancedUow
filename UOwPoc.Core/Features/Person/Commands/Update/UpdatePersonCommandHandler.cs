using AutoMapper;
using MediatR;
using UOwPoc.Core.Interfaces;

namespace UOwPoc.Core.Features.Person.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, Guid>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _uow.QueryRepository<UOWPoc.Entities.Person>().GetById(request.Person.Id);
            if (person == null)
                throw new Exception("Person not found");

            _mapper.Map(request.Person, person);
            _uow.CommandRepository<UOWPoc.Entities.Person>().Update(person);
            var res = await _uow.SaveChangesAsync(cancellationToken);
            if (res > 0)
                return person.Id;
            throw new Exception("Person not updated");
        }
    }
}