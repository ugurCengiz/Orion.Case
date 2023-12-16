using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create;
using Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Delete;
using Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Update;
using Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetById;
using Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetList;

namespace Orion.Case.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneDirectoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListTelephoneDirectoryQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetByIdTelephoneDirectoryQuery { Id = id });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTelephoneDirectoryCommand command)
        {

            CreateTelephoneDirectoryResponse response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] UpdateTelephoneDirectoryCommand command)
        {
            await Mediator.Send(command);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteTelephoneDirectoryCommand { Id = id });
            return Ok("Deleted");
        }

    }
}
