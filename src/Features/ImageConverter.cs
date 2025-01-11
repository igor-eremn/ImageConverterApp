using System;
using System.IO;
using ImageMagick;

namespace ImageConverterApp.Features
{
    public class ImageConverter
    {
        public string ConvertImage(string inputFilePath, string outputFormat, string outputFolder)
        {
            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("The specified file does not exist.");

            string outputFilePath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + "." + outputFormat);

            using var image = new MagickImage(inputFilePath);
            image.Format = outputFormat switch
            {
                "jpg" or "jpeg" => MagickFormat.Jpeg,
                "png" => MagickFormat.Png,
                _ => throw new ArgumentException("Unsupported output format")
            };

            image.Write(outputFilePath);
            return outputFilePath;
        }
    }
}