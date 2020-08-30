using System;
using System.Collections.Generic;

namespace Definitions.ResourceDefinitions {
    [System.Serializable]
    public class Resources {

        private static long titaniumMax = 100000000;
        private static long triniumMax = 10000000;
        private static long naquadahMax = 100000;
        private static long naquadriaMax = 1000;
        private static long zpmMax = 10;

        public Dictionary<string, Resource> resources;

        public DateTime lastUpdateTime;

        public float currentUpdateTime;

        public Resources() {
            this.resources = new Dictionary<string, Resource>();
            this.resources.Add("titanium", new Resource(0, titaniumMax, 0, 10));
            this.resources.Add("trinium", new Resource(0, triniumMax, 0, 2));
            this.resources.Add("naquadah", new Resource(0, naquadahMax, 0, 0.2f));
            this.resources.Add("naquadria", new Resource(0, naquadriaMax, 0, 0.1f));
            this.resources.Add("zpm", new Resource(0, zpmMax, 0, 0.01f));

            this.lastUpdateTime = DateTime.UtcNow;
            this.currentUpdateTime = 0;
        }

        public Resources(Dictionary<string, Resource> resources, DateTime lastUpdateTime, float currentUpdateTime) {
            this.resources = resources;
            this.lastUpdateTime = lastUpdateTime;
            this.currentUpdateTime = currentUpdateTime;
        }
    }
}