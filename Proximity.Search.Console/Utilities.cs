using Proximity.Search.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Proximity.Search.Console
{
    public class Utilities
    {
        SearchResponse _searchResponse = null;
        InputData inputData;
        public SearchResponse ValidateInputs(string[] args)
        {
            if (!IsValidNumerOfParameters(args))
                return _searchResponse;

            if (!IsValidRange(args))
                return _searchResponse;

            if (!IsValidFilePath(args))
                return _searchResponse;

            return null;
        }

        private bool IsValidNumerOfParameters(string[] args)
        {
            bool IsValid = true;

            if (args.Length != 4)
            {
                PopulateSearchResponseErrors("You have not passed all the required input.\n You need to pass 4 inputs with application namein following Order\n\n<application_name> <keyword1> <keyword2> <range> <input_filename>", args);
                IsValid = false;
            }
            return IsValid;
        }

        private bool IsValidFilePath(string[] args)
        {

            var IsValidPath = System.IO.File.Exists(Directory.GetCurrentDirectory() + @"\Input\" + args[3]);
            if (!IsValidPath)
            {
                PopulateSearchResponseErrors("You have not passed all the required input.\n File does not exist.", args);
                return false;
            }
            return true;
        }

        private bool IsValidRange(string[] args)
        {
            int.TryParse(args[2], out int range);
            if (range < 2)
            {
                PopulateSearchResponseErrors("Valid Range should be 2 or greater.", args);
                return false;
            }
            return true;
        }

        private void PopulateSearchResponseErrors(string message, string[] args)
        {
            if (args.Length <= 3)
            {
                return;
            }
            int.TryParse(args[2], out int range);

            _searchResponse = new SearchResponse
            {
                Message = "Valid Range should be 2 or greater.",
                Success = false,
                FileName = args[3],
                Keyword1 = args[0],
                Keyword2 = args[1],
                Range = range
            };

        }

        public void DisplayResults(SearchResponse searchResponse)
        {
            _searchResponse = searchResponse;
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine(@"********** Proximity Search in File ***********");
            System.Console.WriteLine("*********************************************");
            System.Console.WriteLine("Input \n");
            System.Console.WriteLine("Keyword 1 : " + searchResponse.Keyword1 + "\nKeyword 2 : " + searchResponse.Keyword2 + "\nRange : " + searchResponse.Range + "\nFile Name : " + searchResponse.FileName);
            System.Console.WriteLine("*********************************************");

            if (_searchResponse.Success)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("\n Success in Proximity Search");
                System.Console.WriteLine("\n Total Proximity Search Count is : " + _searchResponse.SearchCount);
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Following Error in Proximity Search.\n");
                System.Console.WriteLine(_searchResponse.Message);
            }
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.ReadKey();
            System.Console.WriteLine("Press any key to exit.");
        }
    }
}
