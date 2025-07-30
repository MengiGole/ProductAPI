using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Application.Queries.User;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Controllers.CQRS
{
    [ApiController]
    [Route("api/cqrs/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto dto)
        {
            var command = new CreateUserCommand(dto);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var query = new LoginUserQuery(dto);
            var result = await _mediator.Send(query);
            if (result == null) return Unauthorized();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto dto)
        {
            var command = new UpdateUserCommand(id, dto);
            var user = await _mediator.Send(command);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }
    }
} 