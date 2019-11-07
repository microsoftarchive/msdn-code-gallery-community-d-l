using System;

namespace UsageExample
{
    public class Company
    {
        private readonly int id;
        private readonly string registry;

        public Company(int id, string registry)
        {
            this.id = id;
            this.registry = registry;
        }

        public int ID { get { return id; } }

        public string Registry { get { return registry; } }

        public string Name { get; set; }
    }
}
