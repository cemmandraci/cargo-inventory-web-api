using CargoInventory.Domain.Entities;
using MediatR;

namespace CargoInventory.Application.Commands.Handlers;

public class RegisterCargoItemHandler : IRequestHandler<RegisterCargoItemCommand, Guid>
{
    private static readonly Dictionary<Guid, CargoItem> _cargoStore = new();

    public Task<Guid> Handle(RegisterCargoItemCommand request, CancellationToken cancellationToken)
    {
        var cargo = new CargoItem(request.Description, request.HubCode);
        _cargoStore[cargo.Id] = cargo;
        return Task.FromResult(cargo.Id);
    }
    
    public static IReadOnlyCollection<CargoItem> GetAllCargo() => _cargoStore.Values;
}