using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.Gateways;

public interface IProcessVideoRequestGateway
{
    Task AddAsync(ProcessVideoRequest processVideoRequest, CancellationToken cancellationToken);

    Task<ProcessVideoRequest> GetByIdAsync(Guid processVideoRequestId, CancellationToken cancellationToken);

    Task UpdateAsync(ProcessVideoRequest processVideoRequest, CancellationToken cancellationToken);

    Task<List<ProcessVideoRequest>> GetAllAsync(CancellationToken cancellationToken);
}
