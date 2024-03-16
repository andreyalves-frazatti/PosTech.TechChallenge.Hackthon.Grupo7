using AutoFixture;
using FluentAssertions;
using Moq;
using TechChallenge.Hackthon.Application.Gateways;
using TechChallenge.Hackthon.Application.Services;
using TechChallenge.Hackthon.Application.UseCases.UploadVideo;
using TechChallenge.Hackthon.Domain.Entities;

namespace TechChallenge.Hackthon.UnitTests.UseCases;

public class UploadVideoUseCaseTests
{
    private readonly IFixture _autoFixture = new Fixture();
    private readonly Mock<IAzureBlobStorageService> _mockAzureBlobStorageService;
    private readonly Mock<IProcessVideoRequestGateway> _mockProcessVideoRequestGateway;
    private readonly Mock<IProcessVideoRequestPublisherService> _mockProcessVideoRequestPublisherService;

    public UploadVideoUseCaseTests()
    {
        _mockAzureBlobStorageService = new Mock<IAzureBlobStorageService>();
        _mockProcessVideoRequestGateway = new Mock<IProcessVideoRequestGateway>();
        _mockProcessVideoRequestPublisherService = new Mock<IProcessVideoRequestPublisherService>();
    }

    [Fact]
    public async Task Should_UploadVideo_When_RequestIsValid()
    {
        /* Arrange */
        var request = new UploadVideoUseCaseRequest()
        {
            Name = _autoFixture.Create<string>(),
            Extension = _autoFixture.Create<string>(),
            Stream = null
        };

        var uri = _autoFixture.Create<Uri>();
        var cancellationToken = new CancellationToken();

        _mockAzureBlobStorageService
            .Setup(c => c.UploadAsync(
                It.IsAny<string>(),
                It.IsAny<Stream>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(uri);

        var useCase = new UploadVideoUseCase(
            _mockAzureBlobStorageService.Object,
            _mockProcessVideoRequestGateway.Object,
            _mockProcessVideoRequestPublisherService.Object);

        /* Act */
        var response = await useCase.Handle(request, cancellationToken);

        /* Assert */
        response.Should().NotBeNull();
        response.Id.Should().NotBeEmpty();

        _mockAzureBlobStorageService
            .Verify(c => c.UploadAsync(request.FileName, request.Stream, cancellationToken), Times.Exactly(1));

        _mockProcessVideoRequestGateway
            .Verify(c => c.AddAsync(It.Is<ProcessVideoRequest>(_
                    => _.Id != Guid.Empty
                    && _.Name == request.Name
                    && _.BlobUrlVideo == uri.ToString()), cancellationToken), Times.Exactly(1));

        _mockProcessVideoRequestPublisherService
            .Verify(c => c.PublishAsync(It.Is<ProcessVideoRequest>(_
                    => _.Id != Guid.Empty
                    && _.Name == request.Name
                    && _.BlobUrlVideo == uri.ToString()), cancellationToken), Times.Exactly(1));
    }
}
