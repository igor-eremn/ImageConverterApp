using System;
using System.IO;
using ImageMagick;

//TODO: allow user to select specific folder and convert all images in that folder
//TODO: get dimensions of the image and allow user to resize the image
//TODO: add gui for the application

namespace ImageConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image Converter");
            Console.Write("Enter the path of the image file to convert: ");
            string inputFilePath = Console.ReadLine();

            Console.Write("Choose output format (jpg/png): ");
            string outputFormat = Console.ReadLine()?.ToLower();

            string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string outputFilePath = Path.Combine(downloadsFolder, Path.GetFileNameWithoutExtension(inputFilePath) + "." + outputFormat);

            try
            {
                if (!File.Exists(inputFilePath))
                {
                    Console.WriteLine("The specified file does not exist.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}