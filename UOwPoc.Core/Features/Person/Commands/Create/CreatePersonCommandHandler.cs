using AutoMapper;
using MediatR;
using UOwPoc.Core.Interfaces;

namespace UOwPoc.Core.Features.Person.Commands.Create
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<UOWPoc.Entities.Person>(request.Person);
            _uow.CommandRepository<UOWPoc.Entities.Person>().Add(person);
            var res = await _uow.SaveChangesAsync(cancellationToken);
            if (res > 0)
                return person.Id;
            throw new Exception("Person not added");
        }
    }
}