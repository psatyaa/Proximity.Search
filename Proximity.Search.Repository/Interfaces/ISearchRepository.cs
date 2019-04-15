using Proximity.Search.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Repository.Interfaces
{
    public interface ISearchRepository
    {
        SearchResponse GetDataCount(InputData inputData);
    }
}
