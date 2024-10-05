using AutoMapper;
using MediatR;
using UOwPoc.Core.Interfaces;
using UOwPoc.Core.Models;
using UOwPoc.Core.Specification;

namespace UOwPoc.Core.Features.Person.Queries.GetList
{
    public class GetPeronListQueryHandler : IRequestHandler<GetPeronListQuery, PageResult<PersonListDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPeronListQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PageResult<PersonListDto>> Handle(GetPeronListQuery request, CancellationToken cancellationToken)
        {
            var speci = new BaseSpecifications<UOWPoc.Entities.Person>();
            if (request.Search.SearchCriteria != null)
            {
                if (!string.IsNullOrEmpty(request.Search.SearchCriteria.FirstName))
                    speci = speci.And(new BaseSpecifications<UOWPoc.Entities.Person>(x => x.FirstName.ToLower().Contains(request.Search.SearchCriteria.FirstName.ToLower())));

                if (!string.IsNullOrEmpty(request.Search.SearchCriteria.LastName))
                    speci = speci.And(new BaseSpecifications<UOWPoc.Entities.Person>(x => x.LastName.ToLower().Contains(request.Search.SearchCriteria.LastName.ToLower())));

                if (request.Search.SearchCriteria.NationalityId.HasValue)
                    speci = speci.And(new PersonNationalitySpecifcation(request.Search.SearchCriteria.NationalityId.Value));
            }
            var result = _uow.QueryRepository<UOWPoc.Entities.Person>().FindWithSpecificationPattern(speci, request.Search.PageIndex, request.Search.PageSize);

            return new PageResult<PersonListDto>(result.PageSize, result.PageIndex, result.TotalCount, _mapper.Map<List<PersonListDto>>(result.Items));
        }
    }
}