using RoadTracker.Entities;
using RoadTracker.Services;
using System;

namespace RoadTracker
{
    public class Program
    {
        private static string roadId;

        public static void Main(string[] args)
        {
            roadId = GetRoadId(args);
            var configuration = Configuration.SetupConfiguration();

            var tokenRepository = new TokenRepository(configuration);
            var APIKey = tokenRepository.GetToken();
            var tflService = new TFLRoadService(APIKey);

            var statusFinder = new RoadStatusFinder(tflService);
            var roadInfo = statusFinder.GetRoadInformation(roadId);

            DisplayRoadDetails(roadInfo);
        }

        private static string GetRoadId(string[] roadNames)
        {
            if (roadNames.Length == 0)
            {
                Console.WriteLine("Road name cannot be empty");
                Environment.Exit(1);
            }
            return roadNames[0];
        }

        private static void DisplayRoadDetails(ValidRoad roadInfo)
        {
            if (roadInfo == null)
            {
                Console.WriteLine($"{roadId} is not a valid road");
                Environment.Exit(1);
            }
                Console.WriteLine($"Status of {roadId} is as follows\n\t" +
                        $"Road Status is {roadInfo.StatusSeverity}\n\t" +
                        $"Road Status Description is {roadInfo.StatusSeverityDescription}");
        }
    }
}
