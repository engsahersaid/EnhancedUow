using MediatR;
using UOwPoc.Core.Models;

namespace UOwPoc.Core.Features.Person.Queries.GetList
{
    public class GetPeronListQuery : IRequest<PageResult<PersonListDto>>
    {
        public BaseSearchModel<PersonSearchDto> Search { get; }

        public GetPeronListQuery(BaseSearchModel<PersonSearchDto> search)
        {
            Search = search;
        }
    }
}