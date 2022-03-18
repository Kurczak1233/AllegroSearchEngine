using System.Collections.Generic;

namespace Models
{
    public class Products
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Images { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}