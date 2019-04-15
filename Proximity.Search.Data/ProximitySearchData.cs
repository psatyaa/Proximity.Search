using Proximity.Search.Data.Interfaces;
using Proximity.Search.Domain;

namespace Proximity.Search.Data
{
    public class ProximitySearchData : IProximitySearchData
    {
        public string[] FileContent { get; set; }
        SearchResponse _searchResponse;
        public SearchResponse GetDataCount(InputData inputData)
        {
            int currentPosition = 0, counter = 0;
            IFileReader fileReader = new FileReader();
            FileContent = fileReader.ReadFile(inputData.FilePath);

            if (FileContent.Length == 0)
            {
                CreateResponse(inputData, false, "No Content in File.", counter);
                return _searchResponse;
            }

            foreach (string word in FileContent)
            {
                currentPosition += 1;
                if (word == inputData.Keyword1)
                    GetCount(inputData, currentPosition, ref counter, inputData.Keyword2);
                else if (word == inputData.Keyword2)
                    GetCount(inputData, currentPosition, ref counter, inputData.Keyword1);

            }
            CreateResponse(inputData, true, "Success", counter);
            return _searchResponse;
        }

        private void CreateResponse(InputData inputData, bool success, string message, int counter)
        {
            _searchResponse = new SearchResponse(success, message, inputData.FileName, counter)
            {
                Keyword1 = inputData.Keyword1,
                Keyword2 = inputData.Keyword2,
                Range = inputData.Range,
                FileName = inputData.FileName
            };
        }

        private void GetCount(InputData inputData, int currentPosition, ref int counter, string Keyword)
        {
            int iterationRange = currentPosition + inputData.Range >= FileContent.Length ? FileContent.Length - 1 : currentPosition + inputData.Range - 1;
            for (int i = currentPosition; i < iterationRange; i++)
            {
                if (Keyword == FileContent[i].ToString())
                    counter += 1;
            }
        }
    }
}
