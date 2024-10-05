using MediatR;
using Microsoft.AspNetCore.Mvc;
using UOwPoc.Core.Features.Person.Commands.Create;
using UOwPoc.Core.Features.Person.Commands.Delete;
using UOwPoc.Core.Features.Person.Commands.Update;
using UOwPoc.Core.Features.Person.Queries.GetById;
using UOwPoc.Core.Features.Person.Queries.GetList;
using UOwPoc.Core.Models;

namespace UOWPoc.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public PersonController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<PersonDto> GetByIdAsync(Guid id)
        {
            return await _mediatr.Send(new GetPeronByIdQuery(id));
        }

        [HttpGet]
        public async Task<PageResult<PersonListDto>> GetAllAsync([FromQuery] BaseSearchModel<PersonSearchDto> search)
        {
            return await _mediatr.Send(new GetPeronListQuery(search));
        }

        [HttpPost]
        public async Task<Guid> AddAsync([FromBody] AddPersonDto model)
        {
            return await _mediatr.Send(new CreatePersonCommand(model));
        }

        [HttpPut]
        public async Task<Guid> UpdateAsync([FromBody] UpdatePersonDto model)
        {
            return await _mediatr.Send(new UpdatePersonCommand(model));
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _mediatr.Send(new DeletePersonCommand(id));
        }
    }
}