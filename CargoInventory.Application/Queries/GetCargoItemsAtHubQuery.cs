using CargoInventory.Domain.Entities;
using MediatR;

namespace CargoInventory.Application.Queries;

public record GetCargoItemsAtHubQuery(string HubCode) : IRequest<List<CargoItem>>;