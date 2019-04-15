using Proximity.Search.Domain;
using Proximity.Search.Repository.Interfaces;
using Proximity.Search.Service.Interfaces;
using System;

namespace Proximity.Search.Service
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;

        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }
        public SearchResponse CountProximityData(InputData inputData)
        {
          return  _searchRepository.GetDataCount(inputData);
        }
    }
}
