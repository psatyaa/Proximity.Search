using Proximity.Search.Data.Interfaces;
using Proximity.Search.Domain;
using Proximity.Search.Repository.Interfaces;
using System;

namespace Proximity.Search.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IProximitySearchData _proximitySearchData;

        public SearchRepository(IProximitySearchData proximitySearchData)
        {
            _proximitySearchData = proximitySearchData;
        }
        public SearchResponse GetDataCount(InputData inputData)
        {
            return _proximitySearchData.GetDataCount(inputData);
        }
    }
}
