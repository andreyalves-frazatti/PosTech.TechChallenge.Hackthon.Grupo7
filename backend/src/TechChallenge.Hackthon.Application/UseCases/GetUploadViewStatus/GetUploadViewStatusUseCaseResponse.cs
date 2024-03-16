using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.Application.UseCases.GetUploadViewStatus;

public record GetUploadViewStatusUseCaseResponse(IEnumerable<ProcessVideoRequest>? ProcessVideoRequests);