using MediatR;

namespace RnD.API.Commands
{
    public record AuthCommand(string email) : IRequest<string>;
}
