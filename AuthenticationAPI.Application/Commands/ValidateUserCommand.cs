using MediatR;

namespace AuthenticationAPI.Application.Commands
{
    public class ValidateUserCommand : IRequest<bool>
    {
        public string Email {  get; set; }
        public string Password { get; set; }
    }
}
