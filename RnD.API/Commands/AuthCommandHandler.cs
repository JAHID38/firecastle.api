using MediatR;

namespace RnD.API.Commands
{
    public sealed class AuthCommandHandler : IRequestHandler<AuthCommand, string>
    {
        public async Task<string> Handle(AuthCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult("dummy-token");
        }
    }
}
