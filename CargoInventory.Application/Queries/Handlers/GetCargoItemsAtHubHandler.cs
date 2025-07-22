using CargoInventory.Application.Commands.Handlers;
using CargoInventory.Domain.Entities;
using MediatR;

namespace CargoInventory.Application.Queries.Handlers;

public class GetCargoItemsAtHubHandler : IRequestHandler<GetCargoItemsAtHubQuery, List<CargoItem>>
{
    public Task<List<CargoItem>> Handle(GetCargoItemsAtHubQuery request, CancellationToken cancellationToken)
    {
        var all = RegisterCargoItemHandler.GetAllCargo();
        var filtered = all.Where(c => c.HubCode == request.HubCode).ToList();
        return Task.FromResult(filtered);
    }
}