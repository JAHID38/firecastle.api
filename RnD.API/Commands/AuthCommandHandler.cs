using MediatR;
using RnD.API.Infrastructures.Auth;

namespace RnD.API.Commands
{
    public sealed class AuthCommandHandler(IJwtProvider jwtProvider) : IRequestHandler<AuthCommand, string>
    {
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Handle(AuthCommand command, CancellationToken cancellationToken)
        {

            return await Task.FromResult(_jwtProvider.GenerateToken(command.email));
        }
    }
}
