using MongoDB.Driver;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Infrastructure.Gateways;

public class ProcessVideoRequestGateway(IMongoClient mongoClient) : IProcessVideoRequestGateway
{
    private readonly IMongoCollection<ProcessVideoRequest> _collection = mongoClient
            .GetDatabase("TechChallenge")
            .GetCollection<ProcessVideoRequest>("ProcessVideoRequests");

    public Task AddAsync(ProcessVideoRequest processVideoRequest, CancellationToken cancellationToken)
    {
        _collection.InsertOne(processVideoRequest, null, cancellationToken);

        return Task.CompletedTask;
    }

    public Task<List<ProcessVideoRequest>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _collection.Find(c => true).ToListAsync(cancellationToken);
    }

    public Task<ProcessVideoRequest> GetByIdAsync(Guid processVideoRequestId, CancellationToken cancellationToken)
    {
        var filter = Builders<ProcessVideoRequest>
            .Filter
            .Eq(c => c.Id, processVideoRequestId);

        return _collection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task UpdateAsync(ProcessVideoRequest processVideoRequest, CancellationToken cancellationToken)
    {
        var filter = Builders<ProcessVideoRequest>
            .Filter
            .Eq(c => c.Id, processVideoRequest.Id);

        var update = Builders<ProcessVideoRequest>
            .Update
            .Set(nameof(processVideoRequest.Status), processVideoRequest.Status)
            .Set(nameof(processVideoRequest.BlobUrlVideo), processVideoRequest.BlobUrlVideo)
            .Set(nameof(processVideoRequest.CreatedAt), processVideoRequest.CreatedAt)
            .Set(nameof(processVideoRequest.UpdatedAt), processVideoRequest.UpdatedAt)
            .Set(nameof(processVideoRequest.Status), processVideoRequest.Status)
            .Set(nameof(processVideoRequest.BlobUrlZipImages), processVideoRequest.BlobUrlZipImages);

        return _collection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}
