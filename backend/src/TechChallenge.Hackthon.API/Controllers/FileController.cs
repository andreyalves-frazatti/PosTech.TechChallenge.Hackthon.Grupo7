﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Hackthon.Application.UseCases.DownloadVideo;
using TechChallenge.Hackthon.Application.UseCases.GetUploadVideoStatus;
using TechChallenge.Hackthon.Application.UseCases.UploadVideo;

namespace TechChallenge.Hackthon.API.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> PostAsync(CancellationToken cancellation)
        {
            UploadVideoUseCaseRequest request = new();

            await _mediator.Send(request, cancellation);

            return Ok();
        }

        [HttpGet("{process-id}")]
        public async Task<ActionResult> GetProcessDetailsAsync([FromRoute(Name = "process-id")] Guid processId, CancellationToken cancellation)
        {
            GetUploadVideoStatusUseCaseRequest request = new();

            await _mediator.Send(request, cancellation);

            return Ok();
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