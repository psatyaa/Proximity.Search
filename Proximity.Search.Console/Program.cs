using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Proximity.Search.Data;
using Proximity.Search.Data.Interfaces;
using Proximity.Search.Domain;
using Proximity.Search.Repository;
using Proximity.Search.Repository.Interfaces;
using Proximity.Search.Service;
using Proximity.Search.Service.Interfaces;

namespace Proximity.Search.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = InjectMethods();
            ProcessRequest(args, serviceProvider);
        }

        private static void ProcessRequest(string[] args, ServiceProvider serviceProvider)
        {
            int range = 0;
            var helperUtility = new Utilities();
            var searchResponse = helperUtility.ValidateInputs(args);
            if (searchResponse != null)
            {
                helperUtility.DisplayResults(searchResponse);
                return;
            }
            if (args.Length <= 3) { return; }

            int.TryParse(args[2], out range);
            var inputData = new InputData()
            {
                Keyword1 = args[0],
                Keyword2 = args[1],
                Range = range,
                FileName = args[3],
                FilePath = Directory.GetCurrentDirectory() + @"\Input\" + args[3].ToString()
            };

            var value = serviceProvider.GetService<ISearchService>();
            var searchReponse = value.CountProximityData(inputData);
            helperUtility.DisplayResults(searchReponse);
        }

        private static ServiceProvider InjectMethods()
        {
            return new ServiceCollection()
                          .AddScoped<ISearchService, SearchService>()
                          .AddScoped<ISearchRepository, SearchRepository>()
                          .AddScoped<IProximitySearchData, ProximitySearchData>()
                          .BuildServiceProvider();
        }
    }
}
