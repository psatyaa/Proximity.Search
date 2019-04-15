using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Domain
{
    public class SearchResponse : BaseResponse
    {
        public string FileName { get; set; }
        public int SearchCount { get; set; }
        public string Keyword1 { get; set; }
        public string Keyword2 { get; set; }
        public int Range { get; set; }
        
        public SearchResponse(bool success, string message):base(success,message)
        {

        }
        public SearchResponse():base(true,"Success")
        {

        }
        public SearchResponse(bool success, string message, string fileName, int searchCount) : base(success, message)
        {
            SearchCount = searchCount;
            FileName = fileName;
        }
        public SearchResponse(string fileName,int searchCount) : base(true,"Success")
        {
            SearchCount = searchCount;
            FileName = fileName;
        }
    }
}
