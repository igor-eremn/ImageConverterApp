using System;
using System.IO;
using ImageMagick;

namespace ImageConverterApp.Features
{
    public class ImageConverter
    {
        public void ConvertImage(string inputFilePath, string outputFormat)
        {
            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("The specified file does not exist.");

            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string outputFilePath = Path.Combine(downloadsFolder, Path.GetFileNameWithoutExtension(inputFilePath) + "." + outputFormat);

            using var image = new MagickImage(inputFilePath);
            image.Format = outputFormat switch
            {
                "jpg" or "jpeg" => MagickFormat.Jpeg,
                "png" => MagickFormat.Png,
                _ => throw new ArgumentException("Unsupported output format")
            };

            image.Write(outputFilePath);

            Console.WriteLine($"Image converted successfully and saved to: {outputFilePath}");
        }
    }
}