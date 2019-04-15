using Proximity.Search.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Service.Interfaces
{
    public interface ISearchService
    {
        SearchResponse CountProximityData(InputData inputData);
    }
}
