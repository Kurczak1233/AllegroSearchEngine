using System.Collections.Generic;

namespace Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Similar
    {
        public string id { get; set; }
    }

    public class CategoryPr
    {
        public string id { get; set; }
        public List<Similar> similar { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }

    public class RangeValue
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class OptionsPr
    {
        public bool identifiesProduct { get; set; }
    }

    public class Parameter
    {
        public string id { get; set; }
        public string name { get; set; }
        public RangeValue rangeValue { get; set; }
        public List<string> values { get; set; }
        public List<string> valuesIds { get; set; }
        public List<string> valuesLabels { get; set; }
        public string unit { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public CategoryPr category { get; set; }
        public List<Image> images { get; set; }
        public List<Parameter> parameters { get; set; }
    }

    public class Subcategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }

    public class Path
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class CategoriesPr
    {
        public List<Subcategory> subcategories { get; set; }
        public List<Path> path { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string value { get; set; }
        public string idSuffix { get; set; }
        public int count { get; set; }
        public bool selected { get; set; }
    }

    public class Filter
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public List<Value> values { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public string unit { get; set; }
    }

    public class NextPage
    {
        public string id { get; set; }
    }

    public class GetProductsResult
    {
        public List<Product> products { get; set; }
        public Categories categories { get; set; }
        public List<Filter> filters { get; set; }
        public NextPage nextPage { get; set; }
    }


}