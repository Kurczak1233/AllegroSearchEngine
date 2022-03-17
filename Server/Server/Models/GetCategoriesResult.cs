using System.Collections.Generic;

namespace Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Options
    {
        public bool advertisement { get; set; }
        public bool advertisementPriceOptional { get; set; }
        public bool variantsByColorPatternAllowed { get; set; }
        public bool offersWithProductPublicationEnabled { get; set; }
        public bool productCreationEnabled { get; set; }
        public bool customParametersEnabled { get; set; }
    }

    public class Parent
    {
        public string id { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public bool leaf { get; set; }
        public string name { get; set; }
        public Options options { get; set; }
        public Parent parent { get; set; }
    }

    public class GetCategoriesResult
    {
        public List<Category> categories { get; set; }
    }
}