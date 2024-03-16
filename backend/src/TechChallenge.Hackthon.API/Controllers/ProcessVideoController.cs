using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Hackthon.API.Models;
using TechChallenge.Hackthon.Application.UseCases.DownloadVideo;

namespace TechChallenge.Hackthon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessVideoController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("upload")]
        public async Task<ActionResult> PostUploadVideoAsync([FromForm] PostUploadVideoModel model, CancellationToken cancellation)
        {
            var response = await _mediator.Send(model.ToUseCaseRequest(), cancellation);
            return Ok(response);
        }

        [HttpGet("{process-id}")]
        public async Task<ActionResult> GetFindUploadVideoStatusAsync(GetFindUploadVideoStatusModel model, CancellationToken cancellation)
        {
            var response = await _mediator.Send(model.ToUseCaseRequest(), cancellation);
            return Ok(response);
        }

        [HttpGet("download")]
        public async Task<ActionResult> DownloadZipAsync(CancellationToken cancellation)
        {
            DownloadVideoUseCaseRequest request = new();

            await _mediator.Send(request, cancellation);

            return Ok();
        }
    }
}
