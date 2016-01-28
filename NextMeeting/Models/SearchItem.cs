using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Models
{

    public class SPItemUser
    {
        public String DocId { get; set; }
        public String UserName { get; set; }
        public String Department { get; set; }
        public String JobTitle { get; set; }
        public String Path { get; set; }
        public String PictureUrl { get; set; }
        public String PreferredName { get; set; }
        public String SipAddress { get; set; }
        public String WorkEmail { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
    public class SPItemDoc
    {
        public String Rank { get; set; }
        public String DocId { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String ContentClass { get; set; }
        public String DefaultEncodingURL { get; set; }
        public String DocumentPreviewMetadata { get; set; }
        public String Edges { get; set; }
        public String EditorOwsUser { get; set; }
        public String FileExtension { get; set; }
        public String FileType { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public String Path { get; set; }
        public String SitePath { get; set; }
        public String SiteTitle { get; set; }
        public string AuthorOWSUSER { get; internal set; }
        public string ContentSource { get; internal set; }
        public DateTime Created { get; internal set; }
        public string CreatedBy { get; internal set; }
        public string CreatedById { get; internal set; }
        public DateTime CreatedOWSDATE { get; internal set; }
        public string DetectedLanguage { get; internal set; }
        public string DisplayAuthor { get; internal set; }
        public string EditorOWSUSER { get; internal set; }
        public string Filename { get; internal set; }
        public string HostingPartition { get; internal set; }
        public bool IsContainer { get; internal set; }
        public bool IsDocument { get; internal set; }
        public bool IsExternalContent { get; internal set; }
        public string LinkingUrl { get; internal set; }
        public string ModifiedBy { get; internal set; }
        public string ModifiedById { get; internal set; }
        public DateTime ModifiedOWSDATE { get; internal set; }
        public string ParentId { get; internal set; }
        public string ParentLink { get; internal set; }
        public string PrivacyIndicator { get; internal set; }
        public string SiteID { get; internal set; }
        public string Size { get; internal set; }
        public string UniqueID { get; internal set; }
        public bool ViewableByAnonymousUsers { get; internal set; }
        public bool ViewableByExternalUsers { get; internal set; }
        public string WebApplicationId { get; internal set; }
        public string WebId { get; internal set; }
        public string Language { get; internal set; }
    }

    public class SPKeyValue
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String ValueType { get; set; }

    }
}
