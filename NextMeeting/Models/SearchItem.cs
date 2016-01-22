using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{

    public class SearchItemUser
    {
        public String DocId { get; set; }
        public String UserName { get; set; }

    }
    public class SearchItemDocs
    {
        public String Rank { get; set; }
        public String DocId { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String AuthorOwsUser { get; set; }
        public String ContentClass { get; set; }
        public String ContentTypeId { get; set; }
        public String DefaultEncodingURL { get; set; }
        public String DocumentPreviewMetadata { get; set; }
        public String Edges { get; set; }
        public String EditorOwsUser { get; set; }
        public String FileExtension { get; set; }
        public String FileType { get; set; }
        public String HitHighlightedProperties { get; set; }
        public String HitHighlightedSummary { get; set; }
        public String LastModifiedTime { get; set; }
        public String Path { get; set; }
        public String SPWebUrl { get; set; }
        public String ServerRedirectedPreviewURL { get; set; }
        public String SitePath { get; set; }
        public String SiteTitle { get; set; }


    }

    public class SearchValue
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String ValueType { get; set; }

    }
}
