using Proximity.Search.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Data.Interfaces
{
    public interface IProximitySearchData
    {
        SearchResponse GetDataCount(InputData inputData);
    }
}
