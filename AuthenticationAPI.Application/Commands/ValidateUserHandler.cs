using AuthenticationAPI.Infrastructure;
using MediatR;

namespace AuthenticationAPI.Application.Commands
{
    public class ValidateUserHandler : IRequestHandler<ValidateUserCommand, bool>
    {
        private readonly IUserRepository _service;

        public ValidateUserHandler(IUserRepository service)
        {
            _service = service;
        }

        public async Task<bool> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            return await _service.ValidateUser(request.Email, request.Password);
        }
    }
}
