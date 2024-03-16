using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.Services;

public interface IProcessVideoRequestPublisherService
{
    Task PublishAsync(ProcessVideoRequest request, CancellationToken cancellationToken);
}
