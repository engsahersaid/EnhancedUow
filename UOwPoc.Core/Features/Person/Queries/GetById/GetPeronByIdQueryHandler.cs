using AutoMapper;
using MediatR;
using UOwPoc.Core.Interfaces;

namespace UOwPoc.Core.Features.Person.Queries.GetById
{
    public class GetPeronByIdQueryHandler : IRequestHandler<GetPeronByIdQuery, PersonDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPeronByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(GetPeronByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _uow.QueryRepository<UOWPoc.Entities.Person>().GetByIdAsync(request.Id);
            return _mapper.Map<PersonDto>(person);
        }
    }
}