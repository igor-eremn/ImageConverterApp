//TODO: allow user to select specific folder and convert all images in that folder
//TODO: get dimensions of the image and allow user to resize the image
//TODO: add gui for the application

using System;
using ImageConverterApp.Features;

namespace ImageConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Image Converter App");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Convert an image file (jpg/png)");
                Console.WriteLine("2. Exit");
                Console.Write("Your choice (default is 1): ");

                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    choice = "1";
                }

                switch (choice)
                {
                    case "1":
                        ConvertImageOption();
                        break;
                    case "2":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }

        static void ConvertImageOption()
        {
            Console.Clear();
            Console.WriteLine("Image Converter");

            string inputFilePath;
            while (true)
            {
                Console.Write("Enter the path of the image file to convert ('m' for menu): ");
                inputFilePath = Console.ReadLine();

                if (string.Equals(inputFilePath, "m", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (File.Exists(inputFilePath))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The specified file does not exist. Please try again.");
                }
            }

            Console.Write("Choose output format (jpg/png): ");
            string outputFormat = Console.ReadLine()?.ToLower();

            try
            {
                var imageConverter = new ImageConverter();
                imageConverter.ConvertImage(inputFilePath, outputFormat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}