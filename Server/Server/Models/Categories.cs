using System.Collections.Generic;

namespace Models
{
    public class Categories
    {
        public string Id { get; set; }
        public bool Leaf { get; set; }
        public string Name { get; set; }
        public Options Options { get; set; }
        public Parent Parent { get; set; }
    }
}