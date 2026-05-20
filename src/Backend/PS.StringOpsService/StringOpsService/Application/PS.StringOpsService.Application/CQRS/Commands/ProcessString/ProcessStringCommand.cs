using MediatR;
using PS.StringOpsService.Application.DTOs;

namespace PS.StringOpsService.Application.CQRS.Commands.ProcessString
{
    public sealed record ProcessStringCommand(
        string Input,
        string[] Operations
    ) : IRequest<ProcessStringResult>;
}
