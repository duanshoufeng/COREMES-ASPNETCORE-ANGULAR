using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Models;

namespace Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValueResource Model { get; set; }
        public KeyValueResource Make { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValueResource> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<KeyValueResource>();
        }
    }
}