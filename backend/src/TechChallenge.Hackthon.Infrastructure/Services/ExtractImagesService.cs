using FFMpegCore;
using System.Drawing;
using System.IO.Compression;
using System.Reflection;
using TechChallenge.Hackthon.Application.Services;

namespace TechChallenge.Hackthon.Infrastructure.Services;

public class ExtractImagesService : IExtractImagesService
{
    public Stream GetImages(Stream inputStream)
    {
        var tempFolder = Path.Combine(
            Assembly.GetExecutingAssembly().Location,
            Guid.NewGuid().ToString());

        Directory.CreateDirectory(tempFolder);

        var tempImagesFolder = Path.Combine(tempFolder, "images");

        Directory.CreateDirectory(tempImagesFolder);

        var inputPath = Path.Combine(tempFolder, "temp.mp4");

        using (var outputFileStream = new FileStream(inputPath, FileMode.Create))
        {
            inputStream.CopyTo(outputFileStream);
        }

        var videoInfo = FFProbe.Analyse(inputPath);
        var duration = videoInfo.Duration;

        var interval = TimeSpan.FromSeconds(20);

        for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
        {
            var outputPath = Path.Combine(tempImagesFolder, $"frame_at_{currentTime.TotalSeconds}.jpg");
            FFMpeg.Snapshot(inputPath, outputPath, new Size(1920, 1080), currentTime);
        }

        Directory.Delete(tempFolder);

        string destinationZipFilePath = Path.Combine(tempFolder, "images.zip");

        ZipFile.CreateFromDirectory(tempImagesFolder, destinationZipFilePath);

        return new FileStream(destinationZipFilePath, FileMode.Open);
    }
}
