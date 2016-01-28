using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextMeeting.Graph
{
    public class SearchQuery
    {
        public Request request { get; set; }
    }

    public class Request
    {
        public string Querytext { get; set; }
        public string StartRow { get; set; }
        public string RowLimit { get; set; }
        public bool TrimDuplicates { get; set; }
        public string SourceId { get; set; }
        public string RowsPerPage { get; set; }
        public RequestArray SelectProperties { get; set; }
        public RequestArray RefinementFilters { get; set; }
        public RequestArray Refiners { get; set; }
        public PropertiesArray Properties { get; set; }
        public string RankingModelId { get; set; }
        public string QueryTemplate { get; set; }
        public SortArray SortList { get; set; }

    }

    public class RequestArray
    {
        [JsonProperty("results")]
        public List<String> Results { get; set; }

        public RequestArray()
        {
            this.Results = new List<String>();
        }
    }

    public class SortArray
    {
        [JsonProperty("results")]
        public List<SortItem> Results { get; set; }

        public SortArray()
        {
            this.Results = new List<SortItem>();
        }
    }

    public class PropertiesArray
    {
        [Newtonsoft.Json.JsonProperty("results")]
        public List<PropertiesItem> Results { get; set; }
        public PropertiesArray()
        {
            this.Results = new List<PropertiesItem>();
        }
    }

    public class SortItem
    {
        public string Property { get; set; }
        public string Direction{ get; set; }

        public SortItem()
        {
        }
    }
    public class PropertiesItem
    {
        public String Name { get; set; }
        public PropertiesItemValue Value { get; set; }

        public PropertiesItem()
        {
            this.Value = new PropertiesItemValue();
        }
    }

    public class PropertiesItemValue
    {
        public String StrVal { get; set; }
        public bool? BoolVal { get; set; }
        public int? IntVal { get; set; }
        public String[] StrArray { get; set; }

        public int QueryPropertyValueTypeIndex
        {
            get
            {
                if (!String.IsNullOrEmpty(StrVal))
                    return 1;

                if (IntVal.HasValue)
                    return 2;

                if (BoolVal.HasValue)
                    return 3;

                if (StrArray != null)
                    return 4;

                return 5;
            }
        }

    }

    //public class PropertiesItemValue
    //{
    //    public String GraphQuery { get; set; }
    //    public String GraphRankingModel { get; set; }
    //    public int QueryPropertyValueTypeIndex { get; set; }


    //}



    //public class CustomContractResolver : DefaultContractResolver
    //{
    //    protected override JsonConverter ResolveContractConverter(Type objectType)
    //    {
    //        if (objectType == typeof(PropertiesItemValue))
    //            new PropertiesItemConverter(); // pretend converter is not specified

    //        return base.ResolveContractConverter(objectType);
    //    }
    //}
    //public class PropertiesItemConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return objectType == typeof(PropertiesItemValue);

    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
