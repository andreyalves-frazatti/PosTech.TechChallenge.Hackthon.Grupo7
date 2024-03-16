using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;

public record GetUploadVideoStatusUseCaseResponse(IEnumerable<ProcessVideoRequest> ProcessVideoRequests);
