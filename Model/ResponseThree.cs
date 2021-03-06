using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest.Model
{
    public class ResponseThree
    {
        public long Id { get; set; }
        public int Category { get; set; }
        public List<Item> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
    }

    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
    }

    public class ResponseThreeFlatten
    {
        public long Id { get; set; }
        public int Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
