using MediatR;

namespace CargoInventory.Application.Commands;

public record RegisterCargoItemCommand(string Description, string HubCode): IRequest<Guid>;