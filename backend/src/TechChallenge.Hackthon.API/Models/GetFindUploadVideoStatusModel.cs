using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;
namespace TechChallenge.Hackthon.API.Models;

public record GetFindUploadVideoStatusModel
{
    [Required(AllowEmptyStrings = false)]
    [FromRoute(Name = "process-id")]
    public required Guid ProcessVideoRequestId { get; init; }

    public FindUploadVideoStatusUseCaseRequest ToUseCaseRequest()
    {
        return new(ProcessVideoRequestId);
    }
}
